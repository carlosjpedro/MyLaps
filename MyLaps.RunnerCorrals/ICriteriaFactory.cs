using System;
using MyLaps.RunnerCorrals.Model;

namespace MyLaps.RunnerCorrals
{
    interface ICriteriaFactory
    {
        Func<Runner, bool> CreateAgeCriteria(int minAge, int maxAge);
        Func<Runner, bool> CreateGenderCriteria(Gender gender);
        Func<Runner, bool> CreateTimeCriteria(long minTime, long maxTime);
        Func<Runner, bool> DefaultCriteria { get; }
    }
}
