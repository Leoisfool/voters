﻿using System;
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
    [Route("api/DoVote")]
    [EnableCors("AllowSpecificOrigin")]
    public class DoVoteController : Controller
    {       
       // POST: api/DoVote
        [HttpPost]
        public IActionResult Post([FromBody]DoVote value)
        {
            ICache cache = new ICache();
            DBAction db = new DBAction();

            var userId = cache.GetHash(value.Token, "session");
            if (value == null || value.ItemIds == null || userId == null)
            {
                return BadRequest();
            }
            if(db.GetLimitVoteItems(value.VoteId) != value.ItemIds.Length)
            {
                var rdata = new
                {
                    State = 0,
                    ErrorInfo = "投票数和提交数不符"
                };
                return new ObjectResult(JObject.FromObject(rdata));
            }

            if(cache.IsSetContains(value.VoteId.ToString(), userId))
            {
                var rdata = new
                {
                    State = 0,
                    ErrorInfo = "你已经投过票了"
                };
                return new ObjectResult(JObject.FromObject(rdata));
            }

            foreach(var i in value.ItemIds)
            {
                if(!db.checkItemsInVote(value.VoteId, i))
                {
                    var rdata = new
                    {
                        State = 0,
                        ErrorInfo = "VoteId AND ItemId NOT PAIRED"
                    };
                    return new ObjectResult(JObject.FromObject(rdata));
                }
            }
            foreach (var i in value.ItemIds)
            {
                cache.AddScoreZset("score", i.ToString(), 1);
            }
            cache.SetSet(value.VoteId.ToString(), userId);
            var data = new
            {
                State = 1,
            };
            return new ObjectResult(JObject.FromObject(data));
        }
    }
}
