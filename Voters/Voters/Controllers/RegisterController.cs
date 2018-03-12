using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Voters.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;

namespace Voters.Controllers
{
    [Produces("application/json")]
    [Route("api/Register")]
    [EnableCors("AllowSpecificOrigin")]

    public class RegisterController : Controller
    {
        private readonly ILogger _logger;

        // POST: api/Register
        [HttpPost]
        public IActionResult Post([FromBody]UserItem value)
        {
            if(value == null)
            {
                return BadRequest();
            }
            DBAction injj = new DBAction();
            var state = 0;

            UserItem item = new UserItem();
            item.UserName = value.UserName;
            item.Password = value.Password;

            if (injj.InsertUser(item))
            {
                state = 1;
            }

            var data = new
            {
                State = state,
                UserName = value.UserName,
            };

            var json = JObject.FromObject(data);
            return new ObjectResult(json);
        }
        
    }
}
