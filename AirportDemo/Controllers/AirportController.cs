using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using AirportDemo.Core.Models;
using AirportDemo.Services;
using AirportDemo.Services.Interfaces;

namespace AirportDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        public readonly IAirportService _airportService;
        public readonly IMapper _mapper;
        public AirportController(
          IAirportService airportService,
          IMapper mapper
          )
        {
            _airportService = airportService;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status201Created)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAirportList()
        {
            var airportList = await _airportService.GetAirportList();
            var mapingDto = _mapper.Map<List<AirportDto>>(airportList);
            if (airportList == null)
            {
                return NotFound();
            }
            return Ok(mapingDto);
        }


        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("{ID}")]
        public async Task<IActionResult> GetProductById(long ID)
        {
            var AirportDetails = await _airportService.GetAirportById(ID);

            var mapingDto = _mapper.Map<AirportDto>(AirportDetails);
            if (mapingDto != null)
            {
                return Ok(mapingDto);
            }
            else if(mapingDto == null)
            {
                return NotFound();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
