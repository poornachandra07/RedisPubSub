using StackExchange.Redis;
using System;
using System.Threading;

namespace redis_subscriber
{
    class Program
    {
        private const string RedisConnectionString = "localhost:6379";
        private static ConnectionMultiplexer connection = ConnectionMultiplexer.Connect(RedisConnectionString);
        private const string Channel = "test-channel";
        static void Main(string[] args)
        {
            var pubsub = connection.GetSubscriber();

            pubsub.Subscribe(Channel, (channel, message) => Console.Write("\nMessage received from test-channel : " + message));
            while (true){
                Thread.Sleep(5000);
                Console.WriteLine("Listening test-channel");
            }
        }
    }
}
