using StackExchange.Redis;
using System;

namespace redis_publisher
{
    class Program
    {
        private const string RedisConnectionString = "localhost:6379";
        private static ConnectionMultiplexer connection = ConnectionMultiplexer.Connect(RedisConnectionString);
        private const string Channel = "test-channel";

        static void Main(string[] args)
        {
            var pubsub = connection.GetSubscriber();

            while (true)
            {
                Console.Write("Enter your message here..!\n");
                var message = Console.ReadLine();
                pubsub.PublishAsync("1", message, CommandFlags.FireAndForget);
                Console.Write($"Sent: {message}\n");
            }
        }
    }

}
