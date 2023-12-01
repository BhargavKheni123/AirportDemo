using AutoMapper;
using AirportDemo.Core.Entity;
using AirportDemo.Core.Models;
using Route = AirportDemo.Core.Entity.Route;

namespace AirportDemo.Helper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<GeographyLevel1Dto, GeographyLevel1>().ReverseMap();
            CreateMap<AirportDto, Airport>().ReverseMap();
            CreateMap<Route, RouteInputDto>().ReverseMap();
        }
    }
}
