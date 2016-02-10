using System;
using System.Linq;
using CompatibleSoftware.BLL.Repositories;

namespace CompatibleSoftware.BLL.Services
{
    public class GitHubService : IGitHubService
    {
        private readonly IGitHubRepository _gitHubRepository;
       
        public GitHubService(IGitHubRepository gitHubRepository)
        {
            _gitHubRepository = gitHubRepository;
        }
        
        public bool HasCheckedInDuringPeriod(string userName, DateTime startOfPeriod, DateTime endOfPeriod)
        {
            return _gitHubRepository.GetAllUserActivities(userName)
                .Where(
                    a => a.Public && a.Type == "PushEvent" && a.CreatedAt >= startOfPeriod && a.CreatedAt <= endOfPeriod)
                .ToList().Count > 0;
        }
    }
}
