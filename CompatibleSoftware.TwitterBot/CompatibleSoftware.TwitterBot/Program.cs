using System;
using CompatibleSoftware.BLL;

namespace CompatibleSoftware.TwitterBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting up...");

            var twitter = new Twitter();
            
            Console.Write("Enter a message: ");
            var message = Console.ReadLine();

            twitter.SendTweetToUser("KevMain", message);

            Console.WriteLine("Tweet Sent");

            Console.ReadLine();
        }
    }
}
