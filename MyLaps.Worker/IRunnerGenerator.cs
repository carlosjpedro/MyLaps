using System.Collections.Generic;
using MyLaps.Worker.Model;

namespace MyLaps.Worker
{
    public interface IRunnerGenerator
    {
        IEnumerable<Runner> Generate(int count);
    }
}
