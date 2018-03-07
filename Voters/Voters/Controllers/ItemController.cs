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
    [Route("api/Item")]
    public class ItemController : Controller
    {

        [HttpGet]
        public IActionResult Get()
        {
            string id = Request.Query["ItemId"];
            ICache cache = new ICache();
            DBAction db = new DBAction();
            int res = (int)cache.GetZsetValue("score", id);
            ItemItem item = new ItemItem();
            db.GetItemInfo(uint.Parse(id),ref item);
            item.Score = res;
            var json = JObject.FromObject(item);
            return new ObjectResult(json);
        }

        // POST: api/Item
        [HttpPost]
        public IActionResult Post([FromBody]ItemItem value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            DBAction injj = new DBAction();
            ICache cache = new ICache();

            var state = 0;

            ItemItem item = new ItemItem();
            item.VoteId = value.VoteId;
            item.Desc = value.Desc;
            item.DescPicUrl = value.DescPicUrl;
            item.UserId = value.UserId;
            item.Token = value.Token;

            

            if (cache.GetHash(item.Token, "session") != null && injj.InsertItem(item))
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
        
        // PUT: api/Item/5
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
