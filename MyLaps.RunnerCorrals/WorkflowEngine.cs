using System;
using System.Collections.Generic;
using System.Linq;
using MyLaps.RunnerCorrals.Model;
using MyLaps.RunnerCorrals.Model.Settings;

namespace MyLaps.RunnerCorrals
{
    internal class WorkflowEngine : IWorkflowEngine
    {
        private readonly ICriteriaFactory _criteriaFactory;
        private readonly IRunnerGenerator _runnerGenerator;

        internal IDictionary<Corral, Func<Runner, bool>> CorralsFilterDictionary { get; private set; }

        public WorkflowEngine(
            IEnumerable<ICorralSettings> corralSettings,
            ICriteriaFactory criteriaFactory,
            IRunnerGenerator runnerGenerator)
        {
            _criteriaFactory = criteriaFactory;
            this._runnerGenerator = runnerGenerator;
            CorralsFilterDictionary = corralSettings
                .Select(x => new Corral
                {
                    Name = x.Name,
                    MaxElements = x.MaxElements,
                    StartBIBNumber = x.StartBIBNumber
                })
                .ToDictionary(x => x, x => _criteriaFactory.DefaultCriteria);
        }

        public void ApplyTimeCriteria(string corralName, long minTime, int maxTime)
        {
            var corral = GetCorralByName(corralName);
            var criteria = _criteriaFactory.CreateTimeCriteria(minTime, maxTime);

            CorralsFilterDictionary[corral] = criteria;
        }

        private Corral GetCorralByName(string corralName)
        {
            var corral = CorralsFilterDictionary.Keys.FirstOrDefault(x => x.Name == corralName);
            if (corral == null) throw new ArgumentException($"Corral {corralName} does not exist.");
            return corral;
        }

        public void ApplyAgeCriteria(string corralName, int minAge, int maxAge)
        {
            var corral = GetCorralByName(corralName);
            var criteria = _criteriaFactory.CreateAgeCriteria(minAge, maxAge);

            CorralsFilterDictionary[corral] = criteria;
        }

        public void ApplyGenderCriteria(string corralName, Gender gender)
        {
            var corral = GetCorralByName(corralName);
            var criteria = _criteriaFactory.CreateGenderCriteria(gender);

            CorralsFilterDictionary[corral] = criteria;
        }

        public void Distribute()
        {
            var runners = _runnerGenerator.Generate(5000);

            foreach (var runner in runners)
            {
                foreach (var corral in CorralsFilterDictionary.Keys)
                {
                    if (CorralsFilterDictionary[corral](runner) && corral.Count < corral.MaxElements)
                    {
                        corral.Add(runner);
                        break;
                    }
                }
            }
        }

        public IEnumerable<Corral> Corrals
        {
            get { return CorralsFilterDictionary.Keys; }
        }


    }
}