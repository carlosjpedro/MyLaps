using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using Moq;
using MyLaps.RunnerCorrals.Model;
using Xunit;

namespace MyLaps.RunnerCorrals.Tests
{
    public class WorkflowEngineTests
    {
        private Fixture _fixture;
        private FakeCriteriaFactory _criteriaFactory;
        private IEnumerable<TestCorralSettings> _corralSetttings;
        private IWorkflowEngine _workflowEngine;
        private int _defaultCriteriaCalls = 0;
        private Mock<IRunnerGenerator> _runnerGeneratorMock;

        public WorkflowEngineTests()
        {
            _fixture = new Fixture();
            _criteriaFactory = new FakeCriteriaFactory();

            _corralSetttings = new List<TestCorralSettings>
            {
                new TestCorralSettings
                {
                    Name = "A",
                    MaxElements = 50,
                    StartBIBNumber = 1
                },
                new TestCorralSettings
                {
                    Name = "B",
                    MaxElements = 100,
                    StartBIBNumber = 4000
                },
                new TestCorralSettings
                {
                    Name = "C",
                    MaxElements = 2000,
                    StartBIBNumber = 2000
                }
            };
            _runnerGeneratorMock = new Mock<IRunnerGenerator>();
            _workflowEngine = new WorkflowEngine(_corralSetttings, _criteriaFactory, _runnerGeneratorMock.Object);
        }

        [Fact]
        public void WhenNoCriteriaIsApplied_ShouldUseDefaultCriteriaForAllCorrals()
        {
            var runnerCount = 1000;
            var runners = _fixture.CreateMany<Runner>(runnerCount).ToArray();
            _runnerGeneratorMock.Setup(x => x.Generate(It.IsAny<int>()))
                .Returns(runners);
            _workflowEngine.Distribute();

            var corralA = _workflowEngine.Corrals.Single(x => x.Name == "A");
            var corralB = _workflowEngine.Corrals.Single(x => x.Name == "B");
            var corralC = _workflowEngine.Corrals.Single(x => x.Name == "C");
            Assert.Equal(corralA.MaxElements, corralA.Count);
            Assert.Equal(corralB.MaxElements, corralB.Count);
            Assert.Equal(runnerCount - corralA.MaxElements - corralB.MaxElements, corralC.Count);
        }

        [Fact]
        public void WhenAgeCriteriaIsApplied_ShouldUseAgeCriteria()
        {
            var ageCriteriaRunners = 2;
            var runners = _fixture.Build<Runner>()
                .With(x => x.Age, 23)
                .With(x => x.RaceTime, 90)
                .CreateMany(ageCriteriaRunners)
                .ToList();

            runners.InsertRange(runners.Count, _fixture
                .Build<Runner>()
                .With(x => x.Age, 19)
                .With(x => x.RaceTime, 150)
                .CreateMany(1));

            _runnerGeneratorMock.Setup(x => x.Generate(It.IsAny<int>()))
                .Returns(runners);

            _workflowEngine.ApplyTimeCriteria("A", 100, 200);
            _workflowEngine.ApplyAgeCriteria("B", 20, 25);
            _workflowEngine.Distribute();

            var corralA = _workflowEngine.Corrals.Single(x => x.Name == "A");
            var corralB = _workflowEngine.Corrals.Single(x => x.Name == "B");

            Assert.Equal(1, corralA.Count);
            Assert.Equal(ageCriteriaRunners, corralB.Count);
        }

        [Fact]
        public void WhenTimeCriteriaIsAppliedToCorral_ShouldFillWithCorrectRunners()
        {
            var timeCriteriaRunners = 8;
            var runners = _fixture.Build<Runner>().With(x => x.RaceTime, 45).CreateMany(timeCriteriaRunners).ToList();
            runners.InsertRange(runners.Count, _fixture.Build<Runner>().With(x => x.RaceTime, 220).CreateMany(99));
            _runnerGeneratorMock.Setup(x => x.Generate(It.IsAny<int>()))
                .Returns(runners);

            _workflowEngine.ApplyTimeCriteria("A", 40, 50);

            _workflowEngine.Distribute();

            var corralA = _workflowEngine.Corrals.Single(x => x.Name == "A");
            var corralB = _workflowEngine.Corrals.Single(x => x.Name == "B");
            var corralC = _workflowEngine.Corrals.Single(x => x.Name == "C");
            Assert.Equal(8, corralA.Count);
            Assert.Equal(99, corralB.Count);
            Assert.Equal(0, corralC.Count);
        }

        [Fact]
        public void WhenGenderCriteriaIsApplied_ShouldUseAgeCriteria()
        {
            var genderCriteriaRunners = 40;
            var runners = _fixture.Build<Runner>()
                .With(x => x.Gender, Gender.Female)
                .CreateMany(genderCriteriaRunners)
                .ToList();

            runners.InsertRange(runners.Count, _fixture
                .Build<Runner>()
                .With(x => x.Gender, Gender.Male)
                .CreateMany(3000));

            _runnerGeneratorMock.Setup(x => x.Generate(It.IsAny<int>()))
                .Returns(runners);

            _workflowEngine.ApplyGenderCriteria("A", Gender.Female);
            
            _workflowEngine.Distribute();

            var corralA = _workflowEngine.Corrals.Single(x => x.Name == "A");
            var corralB = _workflowEngine.Corrals.Single(x => x.Name == "B");
            var corralC = _workflowEngine.Corrals.Single(x => x.Name == "C");

            Assert.Equal(genderCriteriaRunners, corralA.Count);
            Assert.Equal(corralB.MaxElements, corralB.Count);
            Assert.Equal(corralC.MaxElements, corralC.Count);
        }
    }
}
