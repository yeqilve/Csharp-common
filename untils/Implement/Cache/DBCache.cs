using System;
using System.Collections.Generic;
using System.Text;
using untils.Interface;

namespace untils.Implement.Cache
{
    public class DBCache : ICache
    {
        /// <summary>
        /// Get Cache from Redis
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Dictionary<string, object> GetCache(string item)
        {            
            throw new NotImplementedException();
        }
        /// <summary>
        /// set Cache to redis
        /// </summary>
        /// <param name="dic"></param>
        public void setcache(Dictionary<string, object> dic)
        {
            throw new NotImplementedException();
        }
    }
}
