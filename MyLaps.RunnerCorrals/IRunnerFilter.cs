using System.Collections.Generic;
using MyLaps.RunnerCorrals.Model;

namespace MyLaps.RunnerCorrals
{
    internal interface IRunnerFilter
    {
        IEnumerable<Runner> Apply(IEnumerable<Runner> runners);
    }
}