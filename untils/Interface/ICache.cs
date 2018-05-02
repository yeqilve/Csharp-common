using System;
using System.Collections.Generic;
using System.Text;

namespace untils.Interface
{
    public interface ICache
    {
        void SetCache(Dictionary<string, object> dic);
        Dictionary<string, Object> GetCache(string item);
    }
}
