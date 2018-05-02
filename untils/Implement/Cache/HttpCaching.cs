using System;
using System.Collections.Generic;
using System.Text;

namespace untils.Implement.Cache
{
    public class HttpCaching : Interface.ICache
    {
        public Dictionary<string, object> GetCache(string item)
        {
            throw new NotImplementedException();
        }

        public void SetCache(Dictionary<string, object> dic)
        {
            throw new NotImplementedException();
        }
    }
}
