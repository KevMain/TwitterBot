using System;
using CompatibleSoftware.BLL.Configuration;
using CompatibleSoftware.BLL.Repositories;
using CompatibleSoftware.BLL.Services;

namespace CompatibleSoftware.BLL.Tasks
{
    public class ReminderTask : ITask
    {
        private readonly ITwitterService _twitterService;
        private readonly ITwitterConfiguration _twitterConfiguration;
        private readonly IGitHubConfiguration _gitHubConfiguration;
        private readonly IGitHubService _gitHubService;

        public ReminderTask(ITwitterConfiguration twitterConfiguration, IGitHubConfiguration gitHubConfiguration)
        {
            _twitterConfiguration = twitterConfiguration;
            _gitHubConfiguration = gitHubConfiguration;

            _twitterService =
                new TwitterService(new TwitterRepository(
                    _twitterConfiguration.ConsumerKey,
                    _twitterConfiguration.ConsumerSecret,
                    _twitterConfiguration.Token, 
                    _twitterConfiguration.TokenSecret));

            _gitHubService =
                new GitHubService(new GitHubRepository(
                    _gitHubConfiguration.AppName,
                    _gitHubConfiguration.Token));
        }

        public void Perform()
        {
            var today = DateTime.Now;

            var hasCheckedIn =
                _gitHubService.HasCheckedInDuringPeriod(
                    _gitHubConfiguration.UserName,
                    new DateTime(today.Year, today.Month, today.Day, 0, 0, 0),
                    new DateTime(today.Year, today.Month, today.Day, 23, 59, 59));

            if (!hasCheckedIn)
            {
                _twitterService.SendTweetToUser(_twitterConfiguration.UserName, "Reminder: You have not pushed any code to GitHub today.");
            }
        }
    }
}
