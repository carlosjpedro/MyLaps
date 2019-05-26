using System;
using MyLaps.Worker.Model;

namespace MyLaps.Worker
{
    class CriteriaFactory : ICriteriaFactory
    {
        public Func<Runner, bool> GenerateNumericCriteria(int minValue, int maxValue)
        {
            return runner => runner.Age > minValue && runner.Age < maxValue; 
        }

        public Func<Runner, bool> GenerateGenderCriteria(Gender gender)
        {
            return runner => runner.Gender == gender;
        }
    }
}