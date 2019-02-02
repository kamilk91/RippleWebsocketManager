using System;
using System.Collections.Generic;
using System.Text;
using CSRedis;

namespace RippleType
{


    class RedisConnector
    {

        public string host { get; set; }


        public RedisConnector(string redishost)
        {
            this.host = redishost;
        }




        public RedisClient RClient()
        {
            RedisClient client = new RedisClient(this.host);
            return client;
        }
    }
}



  
