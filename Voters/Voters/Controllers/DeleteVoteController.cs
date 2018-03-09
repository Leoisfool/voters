using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Voters.Models;
using Newtonsoft.Json.Linq;

namespace Voters.Controllers
{
    [Produces("application/json")]
    [Route("api/DeleteVote")]
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
            if (injj.CheckVoteBelongToUser(uint.Parse(userId), value.VoteId) && injj.DeleteVote(value.VoteId))
            {
                state = 1;
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
