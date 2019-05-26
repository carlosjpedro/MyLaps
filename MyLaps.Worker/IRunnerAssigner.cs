using System.Text;
using System.Threading.Tasks;

namespace MyLaps.Worker
{
    public interface IRunnerAssigner
    {
        Task AssignRunners();
    }
}
