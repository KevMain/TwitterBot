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
            twitter.SendTweet("This is some text");

            Console.WriteLine("Tweet Sent");

            Console.ReadLine();
        }
    }
}
