using System;
using System.Collections.Generic;
using System.Linq;
using MyLaps.RunnerCorrals.Model;

namespace MyLaps.RunnerCorrals
{
    internal class RunnerFilter : IRunnerFilter
    {
        private readonly Func<Runner, bool> _criteria;
        public RunnerFilter(Func<Runner, bool> criteria)
        {
            _criteria = criteria;
        }
        public IEnumerable<Runner> Apply(IEnumerable<Runner> runners)
        {
            return runners.Where(_criteria);
        }
    }
}