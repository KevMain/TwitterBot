using System;

namespace CompatibleSoftware.BLL.Services
{
    public interface IGitHubService
    {
        bool HasCheckedInDuringPeriod(string userName, DateTime startOfPeriod, DateTime endOfPeriod);
    }
}