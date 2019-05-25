using System;
using MyLaps.RunnerCorrals.Model;

namespace MyLaps.RunnerCorrals
{
    internal class RunnerGenerator : IRunnerGenerator
    {
        Random _random = new Random();
        public Runner Next()
        {
            return new Runner
            {
                Age = _random.Next(20, 70),
                Gender = _random.Next() % 2 == 0 ? Gender.Male : Gender.Female,
                RaceTime = _random.Next()
            };
        }
    }
}