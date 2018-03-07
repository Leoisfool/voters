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
    [Route("api/Vote")]
    public class VoteController : Controller
    {
        // GET: api/Vote
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Vote/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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

            if (cache.GetHash(value.Token, "session") != null && injj.InsertVote(value))
            {
                state = 1;
            }

            var data = new
            {
                State = state
            };

            var json = JObject.FromObject(data);
            return new ObjectResult(json);
        }
        
        // PUT: api/Vote/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
