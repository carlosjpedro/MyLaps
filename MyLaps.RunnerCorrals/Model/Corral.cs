using System;
using System.Collections.Generic;

namespace MyLaps.RunnerCorrals.Model
{
    public class Corral
    {
        public string Name { get; set; }
        public int MaxElements { get; set; }
        public int StartBIBNumber { get; set; }
        public int Count { get; private set; }
        public void Add(Runner runner)
        {
            _runners.Add(new AssignedRunner(runner, Count + StartBIBNumber));
            Count++;
        }

        private IList<AssignedRunner> _runners = new List<AssignedRunner>();
    }
}
