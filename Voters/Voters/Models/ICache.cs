using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;
using Microsoft.AspNetCore;
namespace Voters.Models
{
    public class ICache
    {
        // redis config
        private static ConfigurationOptions configurationOptions = ConfigurationOptions.Parse("127.0.0.1:6379,password=xxx,connectTimeout=2000");

        //the lock for singleton
        private static readonly object Locker = new object();
        private static readonly object ScoreZsetLocker = new object();

        //singleton
        private static ConnectionMultiplexer redisConn;

        //singleton
        public static ConnectionMultiplexer getRedisConn()
        {
            if (redisConn == null)
            {
                lock (Locker)
                {
                    if (redisConn == null || !redisConn.IsConnected)
                    {
                        redisConn = ConnectionMultiplexer.Connect(configurationOptions);
                    }
                }
            }
            return redisConn;
        }

        public bool SetHash(string key,string filed, string value)
        {
            redisConn = getRedisConn();
            var db = redisConn.GetDatabase();
            return db.HashSet(key, filed, value);
        }

        public string GetHash(string key, string filed)
        {
            redisConn = getRedisConn();
            var db = redisConn.GetDatabase();
            string res;
            try
            {
                res = db.HashGet(key, filed).ToString();
            }
            catch
            {
                return null;
            }
            return res; 
        }



        public bool DelHash(string key, string filed)
        {
            redisConn = getRedisConn();
            var db = redisConn.GetDatabase();
            return db.HashDelete(key, filed);
        }

        public bool SetSet(string key, string item)
        {
            redisConn = getRedisConn();
            var db = redisConn.GetDatabase();
            return db.SetAdd(key, item);
        }

        public bool IsSetContains(string key, string item)
        {
            redisConn = getRedisConn();
            var db = redisConn.GetDatabase();
            return db.SetContains(key, item);
        }

        public bool SetZset(string key, string item, double value)
        {
            redisConn = getRedisConn();
            var db = redisConn.GetDatabase();
            return db.SortedSetAdd(key, item, value);
        }

        public double AddScoreZset(string key, string item, double value)
        {
            redisConn = getRedisConn();
            var db = redisConn.GetDatabase();
            lock(ScoreZsetLocker)
            {
                string val = DateTime.Now.ToString();
                return db.SortedSetIncrement(key, item, 1);
            }
        }

        public double GetZsetValue(string key, string member)
        {
            redisConn = getRedisConn();
            var db = redisConn.GetDatabase();
            var res = db.SortedSetScore(key, member);
            if (res.HasValue)
            {
                return res.Value;
            }
            return 0;
        }

        public async Task<double> AddZsetValue(string key, string item, double values)
        {
            redisConn = getRedisConn();
            var db = redisConn.GetDatabase();
            return await db.SortedSetIncrementAsync(key, item, values);
        }

    }
}
