
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StackExchange.Redis;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MsStore.Cache
{
    public class CacheService : ICacheService,IDisposable
    {
        IDatabase _redisDB;
        ConnectionMultiplexer _redis;
        public CacheService()
        {
            // Connect to the Redis server
           
            _redis = ConnectionMultiplexer.Connect("127.0.0.1");
           
            // Get a reference to the Redis database
            _redisDB = _redis.GetDatabase();
            // ... Your Redis operations go here ...
            //// Disconnect from Redis
            //redis.Close();
        }
        public async Task Add<TModel>(string key, TModel data, TimeSpan expire)
        {
            _redisDB.StringSet(key, JsonConvert.SerializeObject(data), expire);
        }

      

        public async Task<TModel> Get<TModel>(string key)
        {
            return JsonConvert.DeserializeObject<TModel>(_redisDB.StringGet(key).ToString());
        }

        public async Task Remove(string key)
        {
            _redisDB.KeyDelete(key);
        }

        public void Dispose()
        {
            try
            {
                _redis.Close();
            }
            catch (Exception ex) { }
        }
    }

    public interface ICacheService
    {
        Task Add<TModel>(string key, TModel data, TimeSpan expire);
        Task Remove(string key);
        Task<TModel> Get<TModel>(string key);
    }
}
