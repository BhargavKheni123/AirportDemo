using AirportDemo.Core.Interfaces;
using AirportDemo.Services.Interfaces;

namespace AirportDemo.Services
{
    public class AirportGroupService : IAirportGroupService
    {

        public IUnitOfWork _unitOfWork;

        public AirportGroupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
