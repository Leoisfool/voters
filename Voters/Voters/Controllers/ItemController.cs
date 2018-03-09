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
    [Route("api/Item")]
    [EnableCors("AllowSpecificOrigin")]
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
        
        // PUT: api/Item/
        [HttpPut]
        public IActionResult Put([FromBody]ItemItem value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            DBAction injj = new DBAction();
            var state = 0;

            ICache cache = new ICache();
            string userId;
            if((userId = cache.GetHash(value.Token, "session")) == null)
            {
                return BadRequest();
            } 
            if (injj.CheckVoteBelongToUser(uint.Parse(userId) ,value.VoteId) && injj.checkItemsInVote(value.VoteId, value.ItemId) &&  injj.UpdateItenItem(value))
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
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
