using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyLaps.Worker;

namespace MyLaps.Web.Controllers
{
    public class RunnersController : Controller
    {
        private readonly IRunnerService _runnerService;

        public RunnersController(IRunnerService runnerService)
        {
            _runnerService = runnerService;
        }

        public IActionResult Index()
        {
            var runners = _runnerService.GetAll();
            return View(runners);
        }
    }
}