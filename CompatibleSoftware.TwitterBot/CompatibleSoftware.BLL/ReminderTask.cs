using System;

namespace CompatibleSoftware.BLL
{
    public class ReminderTask : ITask
    {
        private readonly ITwitter _twitter;
        private readonly IGitHub _gitHub;

        public ReminderTask(ITwitter twitter, IGitHub gitHub)
        {
            _twitter = twitter;
            _gitHub = gitHub;
        }

        public void Perform()
        {
            var today = DateTime.Now;

            var hasCheckedIn =
                _gitHub.HasCheckedInDuringPeriod(
                    new DateTime(today.Year, today.Month, today.Day, 0, 0, 0),
                    new DateTime(today.Year, today.Month, today.Day, 23, 59, 59));

            if (!hasCheckedIn)
            {
                _twitter.SendTweetToUser("Reminder: You have not pushed any code to GitHub today.");
            }
        }
    }
}
