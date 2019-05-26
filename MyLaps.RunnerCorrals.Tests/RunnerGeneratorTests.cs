using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using MyLaps.RunnerCorrals.Model;
using Xunit;

namespace MyLaps.RunnerCorrals.Tests
{
    public class RunnerGeneratorTests
    {
        private readonly IRunnerGenerator _runnerGenerator = new RunnerGenerator();

        [Fact]
        public void GenerateShouldGenerateRunners()
        {
            var runners = _runnerGenerator.Generate(2);
            Assert.Equal(2, runners.Count());
        }

        [Fact]
        public void EveryNewGeneratedRunnerIsDifferentToThePreviousOne()
        {
            var runners = _runnerGenerator.Generate(5000).Distinct();
            Assert.Equal(5000, runners.Count());
        }
    }
}
