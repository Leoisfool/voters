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
    [Route("api/Login")]
    [EnableCors("AllowSpecificOrigin")]
    public class LoginController : Controller
    {
        // GET: api/Login
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Login
        [HttpPost]
        public IActionResult Post([FromBody]UserItem value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            DBAction injj = new DBAction();
            ICache cache = new ICache();

            var state = 0;
            var userId = -1;
            var token = "";

            UserItem item = new UserItem();
            item.UserName = value.UserName;
            item.Password = value.Password;
            token = ControllerTools.CreateMD5Hash(userId + ControllerTools.GetTimeStamp());
            if ((userId = injj.CheckAccount(item)) >= 0 &&  cache.SetHash(token, "session", userId.ToString()))
            {
                state = 1;
            }

            var data = new
            {
                State = state,
                Token = token,
                UserId = userId
            };

            var json = JObject.FromObject(data);
            return new ObjectResult(json);
        }
    }
}
