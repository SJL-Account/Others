using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceStack.Redis;


namespace RedisDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            RedisClient redis = new RedisClient("127.0.0.1",6379);
            redis.AddItemToSortedSet("sjl","js",1);
            redis.AddItemToSortedSet("sjl",".Net",2);
            redis.AddItemToSortedSet("sjl","java",3);
            foreach (var item in redis.GetAllItemsFromSortedSetDesc("sjl"))
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
