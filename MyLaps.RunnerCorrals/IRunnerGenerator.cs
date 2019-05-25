using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLaps.RunnerCorrals.Model;
using MyLaps.RunnerCorrals.Model.Settings;

namespace MyLaps.RunnerCorrals
{
    public interface IRunnerGenerator
    {
        Runner Next();
    }

    interface IWorkflowEngine
    {
        void GenerateCorrals();
    }

    internal class WorkflowEngine : IWorkflowEngine
    {
        private IEnumerable<ICorralSettings> _corralSettings;
        internal IEnumerable<Corral> Corrals { get; private set; }
        public WorkflowEngine(IEnumerable<ICorralSettings> corralSettings)
        {
            _corralSettings = corralSettings;
        }

        public void GenerateCorrals()
        {
            Corrals = _corralSettings.Select(x => new Corral{
                Name = x.Name,
                MaxElements = x.MaxElements,
                StartBIBNumber = x.StartBIBNumber
            });
        }

        public void ApplyTimeCriteriaToCorral(string corralName, int minTime, int maxTime)
        {

        }
    }
}
