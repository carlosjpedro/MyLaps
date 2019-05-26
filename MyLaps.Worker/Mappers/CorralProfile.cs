using AutoMapper;
using MyLaps.DataAccess.Entities;
using MyLaps.Worker.Model;

namespace MyLaps.Worker.Mappers
{
    public class CorralProfile : Profile
    {
        public CorralProfile()
        {
            CreateMap<Corral, CorralEntity>()
                .ReverseMap();
        }
    }
}