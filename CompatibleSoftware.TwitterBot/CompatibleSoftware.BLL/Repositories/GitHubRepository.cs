using System.Collections.Generic;
using Octokit;

namespace CompatibleSoftware.BLL.Repositories
{
    public class GitHubRepository : IGitHubRepository
    {
        private readonly GitHubClient _gitHubClient;

        public GitHubRepository(string appName, string token)
        {
            _gitHubClient = new GitHubClient(new ProductHeaderValue(appName))
            {
                Credentials = new Credentials(token)
            };
        }

        public IReadOnlyList<Activity> GetAllUserActivities(string username)
        {
            return _gitHubClient.Activity.Events.GetAllUserPerformed(username).Result;
        }
    }
}
