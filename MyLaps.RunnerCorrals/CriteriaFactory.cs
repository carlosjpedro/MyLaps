using System;
using MyLaps.RunnerCorrals.Model;

namespace MyLaps.RunnerCorrals
{
    class CriteriaFactory : ICriteriaFactory
    {
        public Func<Runner, bool> CreateAgeCriteria(int minAge, int maxAge)
        {
            if (minAge >= maxAge) throw new ArgumentException();

            return runner => runner.Age >= minAge && runner.Age <= maxAge;
        }

        public Func<Runner, bool> CreateGenderCriteria(Gender filteredGender)
        {
            return runner => runner.Gender == filteredGender;
        }

        public Func<Runner, bool> CreateTimeCriteria(long minTime, long maxTime)
        {
            if (minTime >= maxTime) throw new ArgumentException();

            return runner => runner.RaceTime >= minTime && runner.RaceTime <= maxTime;
        }
    }
}