using AutoMapper;
using MyLaps.Web.Models;
using MyLaps.Worker.Model;

namespace MyLaps.Web.Mappers
{
    public class CorralProfile : Profile
    {
        public CorralProfile()
        {
            CreateMap<Corral, CorralViewModel>()
                .ReverseMap();
        }
    }
}
