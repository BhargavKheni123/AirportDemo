using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using AirportDemo.Core.Entity;
using AirportDemo.Core.Models;
using AirportDemo.Services;
using AirportDemo.Services.Interfaces;

namespace AirportDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        public readonly IGeographyLevel1Service _geographyLevel1Service;
        public readonly IAirportService _airportService;
        public readonly IMapper _mapper;
        public CountriesController(IGeographyLevel1Service geographyLevel1Service,
            IAirportService airportService,
            IMapper mapper
            )
        {
            _geographyLevel1Service = geographyLevel1Service;
            _airportService = airportService;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status201Created)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCountryList()
        {
            var productDetailsList = await _geographyLevel1Service.GetCountryList();
            if (productDetailsList == null)
            {
                return NotFound();
            }
            return Ok(productDetailsList);
        }

        [HttpPost]
        public async Task<IActionResult> AddCountry(GeographyLevel1Dto data)
        {
            //var obj = _mapper.Map<GeographyLevel1>(data);

            var Entity = _mapper.Map<GeographyLevel1>(data); 
            try
            {
                var CheckExist = _geographyLevel1Service.GetCountryByName(Entity.Name);
                if (CheckExist == null)
                {
                    var returnData = await _geographyLevel1Service.AddCountry(Entity);
                    if (returnData != null && returnData.GeographyLevel1ID > 0)
                    {
                        return Ok(returnData);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return Conflict("Duplicate value found.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var AirpostCheck = _airportService.GetAirportByCountry(id);
            if(AirpostCheck != null && AirpostCheck.Count > 0)
            {
                return UnprocessableEntity("that a country in use for an airport cannot be deleted");
            }
            var isExists = _geographyLevel1Service.GetCountryById(id);
            if (isExists == null)
            {
                return NotFound("The country could not be found");
            }
            var isCountryDeleted = await _geographyLevel1Service.DeleteCountry(isExists);

            if (isCountryDeleted)
            {
                return Ok("Country Removed Successfully");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
