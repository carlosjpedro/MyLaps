using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MyLaps.DataAccess;
using MyLaps.DataAccess.Entities;
using MyLaps.Worker.Model;

namespace MyLaps.Worker
{
    public class RunnerService : IRunnerService
    {
        private readonly IRunnerGenerator _generator;
        private readonly IRunnerRepository _repository;
        private readonly IMapper _mapper;

        public RunnerService(IRunnerGenerator generator, IRunnerRepository repository, IMapper mapper)
        {
            _generator = generator;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateRunners()
        {
            var runners = _generator.Generate(5000);
            var mappedRunners = _mapper.Map<RunnerEntity[]>(runners);
            await _repository.Save(mappedRunners);
        }

        public void Reset()
        {
            _repository.ResetDatabase();
        }

        public IEnumerable<Runner> GetAll()
        {
            var entities = _repository.GetAll();
            return _mapper.Map<IEnumerable<Runner>>(entities);
        }
    }
}
