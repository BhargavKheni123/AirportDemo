using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using AirportDemo.Services.Interfaces;
using Route = AirportDemo.Core.Entity.Route;
using AirportDemo.Core.Models;

namespace AirportDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        public readonly IRouteService _routeService;
        public readonly IMapper _mapper;
        public RoutesController(
          IRouteService routeService,
          IMapper mapper
          )
        {
            _routeService = routeService;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status201Created)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRouteList()
        {
            var routeList = await _routeService.GetRouteList();
            if (routeList == null)
            {
                return NotFound();
            }
            return Ok(routeList);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoute(RouteInputDto data)
        {
            var mapEntity = _mapper.Map<Route>(data);
            var responseData = await _routeService.AddRoute(mapEntity);
            if (responseData.StatusCode == 200)
                return Ok(responseData.Data);
            else
                return StatusCode(responseData.StatusCode, responseData.Message);
        }
    }
}
