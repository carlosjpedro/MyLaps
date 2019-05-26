using System;
using MyLaps.RunnerCorrals.Model;

namespace MyLaps.RunnerCorrals.Tests
{
    internal class FakeCriteriaFactory : ICriteriaFactory
    {
        public Func<Runner, bool> DefaultCriteria
        {
            get
            {
                return x =>
                {
                    return true;
                };
            }
        }

        public Func<Runner, bool> CreateAgeCriteria(int minAge, int maxAge)
        {
            return runner =>
            {
                return runner.Age >= minAge && runner.Age <= maxAge;
            };
        }

        public Func<Runner, bool> CreateGenderCriteria(Gender gender)
        {
            return runner => { return runner.Gender == gender; };
        }

        public Func<Runner, bool> CreateTimeCriteria(long minTime, long maxTime)
        {
            return runner =>
            {
                return runner.RaceTime >= minTime && runner.RaceTime <= maxTime;
            };
        }
    }
}