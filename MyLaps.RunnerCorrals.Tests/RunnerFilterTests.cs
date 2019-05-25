using System.Collections.Generic;
using System.Linq;
using MyLaps.RunnerCorrals.Model;
using Xunit;

namespace MyLaps.RunnerCorrals.Tests
{
    public class RunnerFilterTests
    {
        [Fact]
        public void WillReturnOnlyItemsThatSatisfiesCriteria()
        {
            bool Criteria(Runner r) => r.Gender == Gender.Female;

            var femaleRunner = new Runner { Age = 10, Gender = Gender.Female, RaceTime = 5543 };
            var runners = new List<Runner>
            {
                femaleRunner,
                new Runner {Age = 25, Gender = Gender.Male, RaceTime = 54653},
                new Runner {Age = 30, Gender = Gender.Male, RaceTime = 6349},
                new Runner {Age = 45, Gender = Gender.Male, RaceTime = 63422},
            };


            var runnerFilter = new RunnerFilter(Criteria);

            //single class fails when there none or no elements in the IEnumerable
            var filteredRunner = runnerFilter.Apply(runners).Single();

            Assert.Equal(femaleRunner, filteredRunner);

        }
    }
}