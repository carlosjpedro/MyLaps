using AutoMapper;
using MyLaps.DataAccess.Entities;

namespace MyLaps.Worker.Mappers
{
    public class RunnerProfile : Profile
    {
        public RunnerProfile()
        {
            CreateMap<RunnerEntity, Model.Runner>()
                .ReverseMap();
        }
    }
}
