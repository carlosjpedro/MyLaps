using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MyLaps.DataAccess;
using MyLaps.DataAccess.Entities;
using MyLaps.Worker.Model;

namespace MyLaps.Worker
{
    class CorralService : ICorralService
    {
        private readonly ICorralRepository _repository;
        private readonly IMapper _mapper;

        public CorralService(ICorralRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Corral>> GetCorrals()
        {
            var corralEntities = await _repository.GetCorrals();
            return _mapper.Map<IEnumerable<Corral>>(corralEntities);
        }

        public void Update(Corral corral)
        {
            var corralEntity = _mapper.Map<CorralEntity>(corral);
            _repository.Save(corralEntity);
        }
    }
}