using AirportDemo.Core.Entity;
using AirportDemo.Core.Models;

namespace AirportDemo.Services.Interfaces
{
    public interface IRouteService
    {
        Task<IEnumerable<RouteDto>> GetRouteList();
        Task<ResponseDto> AddRoute(Route data);
    }
}
