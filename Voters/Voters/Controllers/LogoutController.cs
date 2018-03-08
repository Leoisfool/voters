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
    [Route("api/Logout")]
    [EnableCors("AllowSpecificOrigin")]
    public class LogoutController : Controller
    {
        // GET: api/Logout
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST: api/Logout
        [HttpPost]
        public IActionResult Post([FromBody]JObject value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            var state = 0;
            ICache cache = new ICache();
            if(cache.DelHash(value["Token"].ToString(), "session"))
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

        // PUT: api/Logout/5
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
