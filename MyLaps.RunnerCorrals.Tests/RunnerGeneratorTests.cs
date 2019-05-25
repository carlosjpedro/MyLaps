using System.Collections.Generic;
using MyLaps.RunnerCorrals.Model;
using Xunit;

namespace MyLaps.RunnerCorrals.Tests
{
    public class RunnerGeneratorTests
    {
        private readonly IRunnerGenerator _runnerGenerator = new RunnerGenerator();

        [Fact]
        public void NextShouldGenerateRunner()
        {
            var runner = _runnerGenerator.Next();
        }

        [Fact]
        public void EveryNewGeneratedRunnerIsDifferentToThePreviousOne()
        {
            // Use of Hashset as it only allows unique items
            // Elements already in the list will not be added
            var set = new HashSet<Runner>();

            for (int i = 0; i < 5000; i++)
            {
                set.Add(_runnerGenerator.Next());
            }

            Assert.Equal(5000, set.Count);
        }
    }
}
