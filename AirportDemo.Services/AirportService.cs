using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportDemo.Core.Entity;
using AirportDemo.Core.Interfaces;
using AirportDemo.Services.Interfaces;

namespace AirportDemo.Services
{
    public class AirportService : IAirportService
    {

        public IUnitOfWork _unitOfWork;

        public AirportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<Airport>> GetAirportList()
        {
            var AirportList = await _unitOfWork.Airport.GetAll();
            return AirportList;
        }


        public List<Airport> GetAirportByCountry(int countryId)
        {
            if ( countryId != null && countryId > 0)
            {
                var AirportDetails = _unitOfWork.Airport.GetAll().Result.Where(x => x.GeographyLevel1ID == countryId).ToList();
                if (AirportDetails != null)
                {
                    return AirportDetails;
                }
            }
            return null;
        }

        public async Task<Airport> GetAirportById(long Id)
        {
            if (Id > 0)
            {
                var AirportDetails = await _unitOfWork.Airport.GetById(Id);
                if (AirportDetails != null)
                {
                    return AirportDetails;
                }
            }
            return null;
        }

    }
}
