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
    [Route("api/IfLogin")]
    [EnableCors("AllowSpecificOrigin")]
    public class IfLoginController : Controller
    {
        // POST: api/IfLogin
        [HttpPost]
        public IActionResult Post([FromBody]IfLogin value)
        {
            string token = value.Token;
            DBAction injj = new DBAction();
            var state = 0;

            ICache cache = new ICache();

            if (cache.GetHash(token, "session") != null)
            {
                state = 1;
            }

            var data = new {
                State = state
            };
            return new ObjectResult(JObject.FromObject(data));
        }
    }
}
