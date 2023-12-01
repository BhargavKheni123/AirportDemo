using AirportDemo.Core.Entity;
using AirportDemo.Core.Interfaces;
using AirportDemo.Services.Interfaces;

namespace AirportDemo.Services
{
    public class GeographyLevel1Service : IGeographyLevel1Service
    {

        public IUnitOfWork _unitOfWork;

        public GeographyLevel1Service(IUnitOfWork unitOfWork
           )
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<GeographyLevel1>> GetCountryList()
        {
            var CountryList = await _unitOfWork.GeographyLevel1.GetAll();
            return CountryList;
        }

        public GeographyLevel1 GetCountryById(int Id)
        {
            var CountryDetail = _unitOfWork.GeographyLevel1.GetByIdd(Id);
            return CountryDetail;
            //if (CountryDetail != null)
            //    return true;
            //else
            //    return false;
        }

        public GeographyLevel1 GetCountryByName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var countryDetails = _unitOfWork.GeographyLevel1.GetAll().Result.Where(x => x.Name == name).FirstOrDefault();
                if (countryDetails != null)
                {
                    return countryDetails;
                }
            }
            return null;
        }

        public async Task<GeographyLevel1> AddCountry(GeographyLevel1 data)
        {
            //GeographyLevel1 obj = _mapper.Map<GeographyLevel1>(data);
            if (data != null)
            {
                await _unitOfWork.GeographyLevel1.Add(data);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return data;
                else
                    return null;
            }
            return null;
        }

        public async Task<bool> DeleteCountry(GeographyLevel1 data)
        {
            if (data != null)
            {
                _unitOfWork.GeographyLevel1.Delete(data);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }

            return false;
        }
    }
}
