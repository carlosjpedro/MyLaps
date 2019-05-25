using System;
using System.Text;
using MyLaps.RunnerCorrals.Model;

namespace MyLaps.RunnerCorrals
{
    interface ICriteriaFactory
    {
        Func<Runner, bool> CreateAgeCriteria(int minAge, int maxAge);
        Func<Runner, bool> CreateGenderCriteria(Gender filteredGender);
        Func<Runner, bool> CreateTimeCriteria(long minTime, long maxTime);
    }
}
