using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using MyLaps.DataAccess.Entities;
using MyLaps.Worker.Mappers;
using MyLaps.Worker.Model;
using Xunit;

namespace MyLaps.Worker.Tests.Mappers
{
    public class RunnerProfileTests
    {
        private readonly IMapper _mapper
            ;

        public RunnerProfileTests()
        {
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<RunnerProfile>())
                .CreateMapper();
        }

        [Fact]
        public void MapsModelToDataAccessEntity()
        {
            var runner = new Runner
            {
                RaceTime = 10,
                Gender = Gender.Male,
                Age = 55,
                CorralId = 27
            };

            var runnerEntity = _mapper.Map<RunnerEntity>(runner);
            Assert.Equal(10, runnerEntity.RaceTime);
            Assert.Equal(GenderEntity.Male, runnerEntity.Gender);
            Assert.Equal(55, runnerEntity.Age);
            Assert.Equal(27, runnerEntity.CorralId);
        }

        [Fact]
        public void MapsDataAccessEntityToModel()
        {
            var runner = new RunnerEntity
            {
                RaceTime = 6734,
                Gender = GenderEntity.Female,
                Age = 21
            };

            var runnerEntity = _mapper.Map<Runner>(runner);
            Assert.Equal(6734, runnerEntity.RaceTime);
            Assert.Equal(Gender.Female, runnerEntity.Gender);
            Assert.Equal(21, runnerEntity.Age);
            Assert.Null(runnerEntity.CorralId);
        }

        [Fact]
        public void CamMapCollectionOfItems()
        {
            var runner = new RunnerEntity
            {
                RaceTime = 6734,
                Gender = GenderEntity.Female,
                Age = 21
            };

            var runnerEntityCollection = Enumerable.Repeat(runner, 50000);

            var runnerCollection = _mapper.Map<Runner[]>(runnerEntityCollection);

            Assert.Equal(50000, runnerCollection.Length);
        }
    }
}
