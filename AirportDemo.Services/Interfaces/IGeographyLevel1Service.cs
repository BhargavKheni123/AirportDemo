using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportDemo.Core.Entity;
using AirportDemo.Core.Models;

namespace AirportDemo.Services.Interfaces
{
    public interface IGeographyLevel1Service
    {
        Task<GeographyLevel1> AddCountry(GeographyLevel1 data);
        Task<IEnumerable<GeographyLevel1>> GetCountryList();
        Task<bool> DeleteCountry(GeographyLevel1 data);
        GeographyLevel1 GetCountryByName(string name);
        GeographyLevel1 GetCountryById(int Id);

    }
}
