using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memcached.ClientLibrary;

namespace mmTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //架设两个服务器集群
            string[] IPStrings = new string[] { "127.0.0.1:11211" };
            SockIOPool pool = SockIOPool.GetInstance();
            pool.SetServers(IPStrings);
            pool.Initialize();

            MemcachedClient client = new MemcachedClient();
            client.EnableCompression = false;
            client.Set("nll", 123, 600);
            Console.WriteLine("ok");
            Console.ReadKey();
            //架设服务器集群
            //string[] ips = new string[]
            //{
            //    "127.0.0.1:11211"
            //};

            ////通信池的初始化
            //SockIOPool pool = SockIOPool.GetInstance();
            //pool.SetServers(ips);
            //pool.Initialize();

            ////创建客户端对象，完成通信
            //MemcachedClient client = new MemcachedClient();
            //client.EnableCompression = false;
            //client.Set("zxh", 123, 600);

            //Console.WriteLine("ok");
            //Console.ReadKey();
        }
    }
}
