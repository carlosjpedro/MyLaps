using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MyLaps.DataAccess;
using MyLaps.DataAccess.Entities;
using MyLaps.Worker.Model;

namespace MyLaps.Worker
{
    class RunnerAssigner : IRunnerAssigner
    {
        private readonly IRunnerRepository _runnerRepository;
        private readonly ICorralRepository _corralRepository;
        private readonly ICriteriaFactory _criteriaFactory;
        private readonly IMapper _mapper;

        public RunnerAssigner(IRunnerRepository runnerRepository, ICorralRepository corralRepository, ICriteriaFactory criteriaFactory, IMapper mapper)
        {
            _runnerRepository = runnerRepository;
            _corralRepository = corralRepository;
            _criteriaFactory = criteriaFactory;
            _mapper = mapper;
        }

        public async Task AssignRunners()
        {
            var runnerEntities = _runnerRepository.GetAll();
            var runners = _mapper.Map<IEnumerable<Runner>>(runnerEntities);

            var corralEntities = await _corralRepository.GetCorrals();
            var corrals = _mapper.Map<IEnumerable<Corral>>(corralEntities);
            var criteriaCorral = new Dictionary<Corral, Func<Runner, bool>>();

            foreach (var corral in corrals)
            {
                Func<Runner, bool> criteria;
                if (corral.Name != "D")
                {

                    switch (corral.CriteriaType)
                    {
                        case CriteriaType.RaceTime:
                            criteria = _criteriaFactory.GenerateNumericCriteria(corral.MinRaceTime.Value, corral.MaxRaceTime.Value);
                            break;
                        case CriteriaType.Age:
                            criteria = _criteriaFactory.GenerateNumericCriteria(corral.MinAge.Value, corral.MaxAge.Value);
                            break;
                        case CriteriaType.Gender:
                            criteria = _criteriaFactory.GenerateGenderCriteria(corral.Gender);
                            break;
                        default:
                            criteria = runner => true;
                            break;
                    }
                }
                else
                {
                    criteria = runner => true;
                }
                criteriaCorral.Add(corral, criteria);
            }

            foreach (var runner in runners)
            {
                foreach (var corral in criteriaCorral.Keys)
                {
                    if (criteriaCorral[corral](runner) && corral.RunnerCount < corral.MaxElements)
                    {
                        runner.CorralId = corral.Id;
                        runner.BIBNumber = corral.StartBIBNumber + corral.RunnerCount;
                        runner.CorralName = corral.Name;
                        corral.RunnerCount++;
                        break;
                    }
                }
            }
            runnerEntities = _mapper.Map<IEnumerable<RunnerEntity>>(runners);
            await _runnerRepository.UpdateAllRunners(runnerEntities);


        }
    }
}