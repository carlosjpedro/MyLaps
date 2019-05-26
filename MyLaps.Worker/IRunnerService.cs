using System.Collections.Generic;
using System.Threading.Tasks;
using MyLaps.Worker.Model;

namespace MyLaps.Worker
{
    public interface IRunnerService
    {
        Task CreateRunners();
        void Reset();
        IEnumerable<Runner> GetAll();
    }
}