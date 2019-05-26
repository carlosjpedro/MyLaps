using MyLaps.RunnerCorrals.Model;
using System.Collections.Generic;

namespace MyLaps.RunnerCorrals
{
    public interface IWorkflowEngine
    {
        void ApplyTimeCriteria(string corralName, long minTime, int maxTime);
        IEnumerable<Corral> Corrals { get; }
        void Distribute();
        void ApplyGenderCriteria(string corralName, Gender female);
        void ApplyAgeCriteria(string corralName, int minAge, int maxAge);
    }
}
