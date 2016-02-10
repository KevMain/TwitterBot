using System;
using CompatibleSoftware.BLL;

namespace CompatibleSoftware.TwitterBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting up...");

            Console.WriteLine("Connecting to GitHub");

            var gitHub = new GitHub();

            Console.WriteLine("Checking GitHub History");

            var today = DateTime.Now;

            var hasCheckedIn =
                gitHub.HasCheckedInDuringPeriod(
                    new DateTime(today.Year, today.Month, today.Day, 0, 0, 0),
                    new DateTime(today.Year, today.Month, today.Day, 23, 59, 59));

            if (!hasCheckedIn)
            {
                var twitter = new Twitter();

                twitter.SendTweetToUser("Reminder: You have not pushed any code to GitHub today.");

                Console.WriteLine("Tweet Sent");
            }
            else
            {
                Console.WriteLine("No Tweet Sent");
            }

            Console.ReadLine();
        }
    }
}
