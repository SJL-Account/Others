using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memcached.ClientLibrary;

namespace DLOA.Common
{
    public class MemcachedHelper
    {
        MemcachedClient client;
        public MemcachedHelper()
        {
            //读取IP
            string[] IPStrings= System.Configuration.ConfigurationManager.AppSettings["memcachedIP"].Split(',');
            //架设服务器集群            
            SockIOPool pool = SockIOPool.GetInstance();
            pool.SetServers(IPStrings);
            pool.Initialize();
           client = new MemcachedClient();

        }

        public object get(string guid)
        {
            return client.Get(guid);
        }
        public bool set(string guid, object value,DateTime expireTime)
        {
           return client.Set(guid, value, expireTime);
        }
        public bool Delete(string guid)
        {
           return  client.Delete(guid);
        }
    }
}
