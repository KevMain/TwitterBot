using System.Collections.Generic;
using Octokit;

namespace CompatibleSoftware.BLL.Repositories
{
    public interface IGitHubRepository
    {
        IReadOnlyList<Activity> GetAllUserActivities(string username);
    }
}