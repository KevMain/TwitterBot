using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Octokit;

namespace CompatibleSoftware.BLL
{
    public class GitHub : IGitHub
    {
        private readonly IGitHubConfiguration _gitHubConfiguration;
        private readonly GitHubClient _gitHubClient;

        public GitHub(IGitHubConfiguration gitHubConfiguration)
        {
            _gitHubConfiguration = gitHubConfiguration;
            
            _gitHubClient = new GitHubClient(new ProductHeaderValue(_gitHubConfiguration.AppName))
            {
                Credentials = new Credentials(_gitHubConfiguration.Token)
            };
        }
        
        public bool HasCheckedInDuringPeriod(DateTime startOfPeriod, DateTime endOfPeriod)
        {
            var commits = GetAllPushEventsForUserInTimePeriod(startOfPeriod, endOfPeriod);
            return commits.Count > 0;
        }

        private async Task<IReadOnlyList<Activity>> GetAllUserActivities()
        {
            return await _gitHubClient.Activity.Events.GetAllUserPerformed(_gitHubConfiguration.UserName);
        }

        private List<Activity> GetAllPushEventsForUserInTimePeriod(DateTime startDate, DateTime endDate)
        {
            return
                GetAllUserActivities()
                    .Result.Where(
                        a => a.Public && a.Type == "PushEvent" && a.CreatedAt >= startDate && a.CreatedAt <= endDate)
                    .ToList();
        }
    }
}
