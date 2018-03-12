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
    [Route("api/GetUserName")]
    public class GetUserNameController : Controller
    {
        // GET: api/GetUserName
        [HttpGet]
        public IActionResult Get()
        {
            string cc = Request.Query["userid"];
            DBAction injj = new DBAction();

            if (cc == null)
            {
                return BadRequest();
            }
            string UserName = "";
            try
            {
                UserName = injj.GetUserNameFromUserId(uint.Parse(cc));
            }
            catch
            {
                return BadRequest();
            }
            var res = new
            {
                UserName = UserName
            };
            var json = JObject.FromObject(res);
            return new ObjectResult(json);
        }
    }
}
