using MyLaps.RunnerCorrals.Model;
using System.Collections.Generic;

namespace MyLaps.RunnerCorrals
{
    public interface IRunnerGenerator
    {
        IEnumerable<Runner> Generate(int count);
    }
}
