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
    [Route("api/DeleteVote")]
    [EnableCors("AllowSpecificOrigin")]

    public class DeleteVoteController : Controller
    {   
        // POST: api/DeleteVote
        [HttpPost]
        public IActionResult Post([FromBody] VoteItem value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            DBAction injj = new DBAction();
            ICache cache = new ICache();

            string userId;
            var state = 0;
            if ((userId = cache.GetHash(value.Token, "session")) == null)
            {
                return BadRequest();
            }
            try
            {
                if (injj.CheckVoteBelongToUser(uint.Parse(userId), value.VoteId) && injj.DeleteVote(value.VoteId))
                {
                    state = 1;
                }
            }
            catch
            {
                return BadRequest();
            }
            

            var data = new
            {
                State = state,
            };

            var json = JObject.FromObject(data);
            return new ObjectResult(json);
        }
    }
}
