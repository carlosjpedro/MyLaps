using System;
using System.Collections.Generic;
using MyLaps.Worker.Model;

namespace MyLaps.Worker
{
    internal class RunnerGenerator : IRunnerGenerator
    {
        private readonly Random _random = new Random();
        public IEnumerable<Runner> Generate(int count)
        {
            for (var i = 0; i < count; i++)
            {
                yield return new Runner
                {
                    Age = _random.Next(20, 70),
                    Gender = _random.Next() % 2 == 0 ? Gender.Male : Gender.Female,
                    RaceTime = _random.Next()
                };
            }
        }
    }
}