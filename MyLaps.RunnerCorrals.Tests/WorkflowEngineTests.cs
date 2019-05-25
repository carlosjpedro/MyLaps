using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using MyLaps.RunnerCorrals.Model.Settings;
using Xunit;

namespace MyLaps.RunnerCorrals.Tests
{

    public class WorkflowEngineTests
    {
        private class TestCorralSettings : ICorralSettings
        {
            public string Name { get; set; }
            public int StartBIBNumber { get; set; }
            public int MaxElements { get; set; }
        }

        private Fixture _fixture;
        private IEnumerable<TestCorralSettings> _corralSetttings;
        private WorkflowEngine _workflowEngine;

        public WorkflowEngineTests()
        {
            _fixture = new Fixture();
            _corralSetttings = _fixture.CreateMany<TestCorralSettings>().AsEnumerable();
            _workflowEngine = new WorkflowEngine(_corralSetttings);
        }

        [Fact]
        public void GenerateCorrals_WillCreateCorralBasedOnSettings()
        {
            _workflowEngine.GenerateCorrals();
            Assert.Equal(_corralSetttings.Count(), _workflowEngine.Corrals.Count());
            foreach (var settings in _corralSetttings)
            {
                var exists = _workflowEngine.Corrals
                    .SingleOrDefault(x =>
                    x.Name == settings.Name && x.MaxElements == settings.MaxElements &&
                    x.StartBIBNumber == settings.StartBIBNumber) != null;

                Assert.True(exists);
            }
        }
    }
}
