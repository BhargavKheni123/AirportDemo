using System.Text;
using AirportDemo.Core.Entity;
using AirportDemo.Core.Interfaces;
using AirportDemo.Core.Models;
using AirportDemo.Services.Interfaces;

namespace AirportDemo.Services
{
    public class RouteService : IRouteService
    {
        public IUnitOfWork _unitOfWork;

        public RouteService(IUnitOfWork unitOfWork
           )
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<RouteDto>> GetRouteList()
        {
            var RouteList = await _unitOfWork.Route.GetAll();
            var change = (from route in _unitOfWork.Route.GetAll().Result.ToList()
                          join routeArriaval in _unitOfWork.AirportGroup.GetAll().Result.ToList() on route.ArrivalAirportGroupID equals routeArriaval.AirportGroupID
                          join routeDeparture in _unitOfWork.AirportGroup.GetAll().Result.ToList() on route.DepartureAirportGroupID equals routeDeparture.AirportGroupID
                          select new RouteDto
                          {
                              RouteId = route.RouteID,
                              ArrivalAirportGroupID = route.ArrivalAirportGroupID,
                              ArrivalAirportId = routeArriaval.AirtportIds,
                              DepartureAirportGroupID = route.DepartureAirportGroupID,
                              DepartureAirportId = routeDeparture.AirtportIds

                          }).ToList();
            return change;
        }


        public async Task<ResponseDto> AddRoute(Route data)
        {
            ResponseDto returnResult = new ResponseDto();
            if (data != null)
            {
                /// Route is avaliable already
                var Isroute = _unitOfWork.Route.GetAll().Result.ToList().Where(x => x.DepartureAirportGroupID == data.DepartureAirportGroupID && x.ArrivalAirportGroupID == data.ArrivalAirportGroupID).FirstOrDefault();
                if (Isroute != null)
                {
                   
                    returnResult.StatusCode = 409;
                    returnResult.Message = "Route is avaliable already";
                    return returnResult;
                }

                // Check if departure group exists
                var departureGroupExists = _unitOfWork.AirportGroup.GetAll().Result.Where(group => group.AirportGroupID == data.DepartureAirportGroupID).FirstOrDefault();
                if (departureGroupExists == null)
                {
                    returnResult.StatusCode = 404;
                    returnResult.Message = "Departure group does not exist.";
                    return returnResult;
                }

                // Check if arrival group exists
                var arrivalGroupExists = _unitOfWork.AirportGroup.GetAll().Result.Where(group => group.AirportGroupID == data.ArrivalAirportGroupID).FirstOrDefault();
                if (arrivalGroupExists == null)
                {
                    returnResult.StatusCode = 404;
                    returnResult.Message = "Arrival group does not exist.";
                    return returnResult;
                }

                var AirportList = _unitOfWork.Airport.GetAll().Result.ToList();
                var ArrialAirport = AirportList.Where(x => x.Type.ToLower().Contains("arrival")).ToList().Select(x => x.AirportID.ToString());
                var DepartureAirport = AirportList.Where(x => x.Type.ToLower().Contains("departure")).ToList().Select(x => x.AirportID.ToString());

                var ActuaArrivalGroupAirport = arrivalGroupExists.AirtportIds.Split(",").ToList().Select(x => x);
                var ActualdepartureGroupAirport = departureGroupExists.AirtportIds.Split(",").ToList().Select(x => x);

                /// Check Arrival Group aiport list are correct or not
                bool isRightArrivalGroup = ActuaArrivalGroupAirport.All(a => ArrialAirport.Contains(a));
                
                /// Check Departure Group aiport list are correct or not
                bool isRightDepartureGroup = ActualdepartureGroupAirport.All(a => DepartureAirport.Contains(a));


                // If both Arrival Airport List in group aad Departure Airport List in group is correct
                if (isRightArrivalGroup && isRightDepartureGroup)
                {


                    /// Save Routes
                    await _unitOfWork.Route.Add(data);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                    {
                        returnResult.StatusCode = 200;
                        returnResult.Message = "Route Added Successfully.";
                        returnResult.Data = data;
                        return returnResult;
                    }
                    else
                    {
                        returnResult.StatusCode = 400;
                        returnResult.Message = "Input data not valid";
                        return returnResult;
                    }

                }
                else
                {
                    string message = string.Empty;
                    if(!isRightArrivalGroup)
                    {
                        returnResult.StatusCode = 400;
                        returnResult.Message = "Arriaval Airport Group Data Not valid,";
                    }
                    if(!isRightDepartureGroup)
                    {
                        returnResult.StatusCode = 400;
                        returnResult.Message += "Departure Airport Group Data Not valid.";
                    }

                    return returnResult;
                }
            }
            return returnResult;
        }
    }
}
