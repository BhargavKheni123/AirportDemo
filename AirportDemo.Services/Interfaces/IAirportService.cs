using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportDemo.Core.Entity;

namespace AirportDemo.Services.Interfaces
{
    public interface IAirportService
    {
        Task<IEnumerable<Airport>> GetAirportList();
        List<Airport> GetAirportByCountry(int countryId);
        Task<Airport> GetAirportById(long Id);
    }
}
