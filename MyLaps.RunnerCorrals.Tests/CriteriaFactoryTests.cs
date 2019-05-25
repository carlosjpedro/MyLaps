using System;
using MyLaps.RunnerCorrals.Model;
using Xunit;

namespace MyLaps.RunnerCorrals.Tests
{
    public class CriteriaFactoryTests
    {
        private readonly ICriteriaFactory _criteriaFactory = new CriteriaFactory();

        [Theory]
        [InlineData(20, 50, 10, false)]
        [InlineData(30, 45, 46, false)]
        [InlineData(40, 60, 44, true)]
        [InlineData(40, 60, 40, true)]
        [InlineData(25, 32, 25, true)]
        public void GeneratedAgeCriteriaWillReturnExpectedResults(
            int minAge, int maxAge,
            int actualAge, bool expectedResult)
        {
            var runner = new Runner
            {
                Gender = Gender.Female,
                Age = actualAge,
                RaceTime = 4715
            };

            var criteria = _criteriaFactory.CreateAgeCriteria(minAge, maxAge);
            Assert.Equal(expectedResult, criteria(runner));
        }

        [Fact]
        public void WhenAgeCriteriaMinAgeIsGreaterThanMaxAgeThrows()
        {
            Assert.Throws<ArgumentException>(() => _criteriaFactory.CreateAgeCriteria(50, 45));
        }

        [Fact]
        public void WhenAgeCriteriaMinAgeIsEqualThanMaxAgeThrows()
        {
            Assert.Throws<ArgumentException>(() => _criteriaFactory.CreateAgeCriteria(50, 45));
        }
        [Fact]
        public void WhenAgeCriteriaMinAgeIsGreaterThanMaxAxgeThrows()
        {
            Assert.Throws<ArgumentException>(() => _criteriaFactory.CreateAgeCriteria(50, 45));
        }

        [Theory]
        [InlineData(Gender.Female, Gender.Female, true)]
        [InlineData(Gender.Female, Gender.Male, false)]
        [InlineData(Gender.Male, Gender.Male, true)]
        [InlineData(Gender.Male, Gender.Female, false)]
        public void GeneratedGenderCriteriaWillReturnExpectedResults(Gender filteredGender, Gender actualGender, bool expectedResult)
        {
            var runner = new Runner
            {
                Gender = actualGender,
                Age = 32,
                RaceTime = 4715
            };

            var criteria = _criteriaFactory.CreateGenderCriteria(filteredGender);
            Assert.Equal(expectedResult, criteria(runner));
        }

        [Theory]
        [InlineData(2, 4, 3, true)]
        [InlineData(200, 205, 200, true)]
        [InlineData(301, 403, 403, true)]
        [InlineData(10, 12, 9, false)]
        [InlineData(55, 67, 68, false)]
        public void GenerateTimeCriteriaWillReturnExpectedResults(
            long minTime,
            long maxTime,
            long actualTime,
            bool expectedResult)
        {
            var runner = new Runner
            {
                Gender = Gender.Male,
                Age = 44,
                RaceTime = actualTime
            };

            var criteria = _criteriaFactory.CreateTimeCriteria(minTime, maxTime);
            Assert.Equal(expectedResult, criteria(runner));
        }

        [Fact]
        public void WhenWhenTimeCriteriaMinTimeIsGraterThanMaxTimeThrows()
        {
            Assert.Throws<ArgumentException>(() => _criteriaFactory.CreateTimeCriteria(97, 42));
        }

        [Fact]
        public void WhenWhenTimeCriteriaMinTimeIsEqualToMaxTimeThrows()
        {
            Assert.Throws<ArgumentException>(() => _criteriaFactory.CreateTimeCriteria(40, 40));
        }
    }
}