using System;

namespace CompatibleSoftware.BLL
{
    public interface IGitHub
    {
        bool HasCheckedInDuringPeriod(DateTime startOfPeriod, DateTime endOfPeriod);
    }
}