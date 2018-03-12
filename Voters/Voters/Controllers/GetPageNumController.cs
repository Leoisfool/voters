using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Cors;
using Voters.Models;

namespace Voters.Controllers
{
    [Produces("application/json")]
    [Route("api/GetPageNum")]
    [EnableCors("AllowSpecificOrigin")]

    public class GetPageNumController : Controller
    {
        // GET: api/GetPageNum
        [HttpGet]
        public IActionResult Get()
        {
            string cc = Request.Query["userid"];
            long count;
            DBAction db = new DBAction();
            if (cc == null)
            {
                count = db.GetAllVoteCount();
            }
            else
            {
                try
                {
                    count = db.GetUserVoteCount(uint.Parse(cc));
                }
                catch
                {
                    return BadRequest();
                }
            }

            long pageNum = 0;
            if (count >= 0)
            {
                pageNum = count/10;
                if(count % 10 != 0)
                {
                    pageNum += 1;
                }
            }
            var data = new
            {
                PageNum = pageNum
            };

            var json = JObject.FromObject(data);
            return new ObjectResult(json);
        }
    }
}
