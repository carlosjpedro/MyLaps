using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyLaps.Web.Models;
using MyLaps.Worker;
using MyLaps.Worker.Model;

namespace MyLaps.Web.Controllers
{
    public class CorralController : Controller
    {
        private readonly ICorralService _corralService;
        private readonly IRunnerService _runnerService;
        private readonly IRunnerAssigner _runnerAssigner;
        private readonly IMapper _mapper;

        public CorralController(ICorralService corralService, IRunnerService runnerService, IRunnerAssigner runnerAssigner, IMapper mapper)
        {
            _corralService = corralService;
            _runnerService = runnerService;
            _runnerAssigner = runnerAssigner;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var corrals = await _corralService.GetCorrals();
            var viewModel = new CorralListViewModel
            {
                Corrals = corrals.Select(x => new CorralViewModel
                {
                    Id = x.Id,
                    MaxElements = x.MaxElements,
                    StartBIBNumber = x.StartBIBNumber,
                    Name = x.Name,
                    CriteriaType =
                        (CriteriaTypeViewModel)Enum.Parse(typeof(CriteriaTypeViewModel), x.CriteriaType.ToString())
                })
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var corral = (await _corralService.GetCorrals()).Single(x => x.Id == id);
            var model = _mapper.Map<CorralViewModel>(corral);
            return View(model);
        }

        public IActionResult Save(CorralViewModel corralViewModel)
        {


            var corral = _mapper.Map<Corral>(corralViewModel);
            _corralService.Update(corral);
            return RedirectToAction("Index");
        }

        public IActionResult Assign()
        {
            _runnerAssigner.AssignRunners();
            return RedirectToAction("Index");
        }

        public IActionResult Reset()
        {
            _runnerService.Reset();
            return RedirectToAction("Index");
        }

        public IActionResult Generate()
        {
            _runnerService.CreateRunners();
            return RedirectToAction("Index");
        }
    }
}