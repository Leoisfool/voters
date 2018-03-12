using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Voters.Models;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Cors;

namespace Voters.Controllers
{
    [Produces("application/json")]
    [Route("api/Vote")]
    [EnableCors("AllowSpecificOrigin")]
    public class VoteController : Controller
    {
        // GET: api/Vote?id=5
        [HttpGet]
        public IActionResult Get()
        {
            string cc = Request.Query["id"];
            uint id;
            try
            {
                id = uint.Parse(cc);
            }
            catch
            {
                return BadRequest();
            }
            VoteItem res = new VoteItem();
            DBAction injj = new DBAction();
            if(injj.GetVoteItem(id, ref res) != true || injj.getItemsInVote(id, ref res) != true)
            {
                return BadRequest();
            }
            
            var json = JObject.FromObject(res);
            return new ObjectResult(json);
        }

        // GET: api/Vote/5 分页
        [HttpGet("{id}")]
        public IActionResult Get(uint id)
        {
            string cc = Request.Query["userid"];

            DBAction injj = new DBAction();
            long count;
            if(cc == null)
            {
                count = injj.GetAllVoteCount();
            }
            else
            {
                try
                {
                    count = injj.GetUserVoteCount(uint.Parse(cc));
                }
                catch
                {
                    return BadRequest();
                }
            }
            if (id <= 0 ||  (id - 1)*10 >= count)
            {
                return BadRequest();
            }
            SplitPageRes res = new SplitPageRes();
            
            
            res.PageNum = id;
            res.SplitNum = 10;
            if(cc == null)
            {
                if (!injj.GetVoteFromNThToMTh(ref res, (id - 1) * 10, id * 10, 10))
                {
                    res.State = 0;
                }
            }
            else
            {
                try
                {
                    if (!injj.GetVoteFromNThToMTh(ref res, (id - 1) * 10, id * 10, 10, uint.Parse(cc)))
                    {
                        res.State = 0;
                    }
                }
                catch
                {
                    return BadRequest();
                }
            }
            
            res.State = 1;
            var json = JObject.FromObject(res);
            return new ObjectResult(json);
        }
        
        // POST: api/Vote
        [HttpPost]
        public IActionResult Post([FromBody]VoteItem value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            DBAction injj = new DBAction();
            var state = 0;

            ICache cache = new ICache();
            UInt64 voteId = 0;
            if (cache.GetHash(value.Token, "session") != null && (voteId = injj.InsertVote(value)) > 0 )
            {
                state = 1;
            }

            var data = new
            {
                State = state,
                VoteId = voteId
            };

            var json = JObject.FromObject(data);
            return new ObjectResult(json);
        }
        
        // PUT: api/Vote/
        [HttpPut]
        public IActionResult Put([FromBody]VoteItem value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            DBAction injj = new DBAction();
            var state = 0;

            ICache cache = new ICache();
            if ( cache.GetHash(value.Token, "session") == value.UserBelong.ToString() && injj.CheckVoteBelongToUser(value.UserBelong, value.VoteId) && injj.UpdateVoteItem(value))
            {
                state = 1;
            }
            var data = new {
               State = state
            };
            var json = JObject.FromObject(data);
            return new ObjectResult(json);
        }
        
    }
}
