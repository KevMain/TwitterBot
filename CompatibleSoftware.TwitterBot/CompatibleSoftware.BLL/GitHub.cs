using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Octokit;

namespace CompatibleSoftware.BLL
{
    public class GitHub
    {
        private readonly GitHubClient _gitHubClient;

        public GitHub()
        {
            var gitHubToken = ConfigurationManager.AppSettings["GitHub.Token"];
            var gitHubAppName = ConfigurationManager.AppSettings["GitHub.AppName"];

            _gitHubClient = new GitHubClient(new ProductHeaderValue(gitHubAppName))
            {
                Credentials = new Credentials(gitHubToken)
            };
        }
        
        public bool HasCheckedInDuringPeriod(DateTime startOfPeriod, DateTime endOfPeriod)
        {
            var commits = GetAllPushEventsForUserInTimePeriod(startOfPeriod, endOfPeriod);
            return commits.Count > 0;
        }

        private async Task<IReadOnlyList<Activity>> GetAllUserActivities()
        {
            var gitHubUser = ConfigurationManager.AppSettings["GitHub.User"];
            
            return await _gitHubClient.Activity.Events.GetAllUserPerformed(gitHubUser);
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
