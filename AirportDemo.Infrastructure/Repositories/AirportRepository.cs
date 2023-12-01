using AirportDemo.Core.Entity;
using AirportDemo.Core.Interfaces;

namespace AirportDemo.Infrastructure.Repositories
{
    public class AirportRepository : GenericRepository<Airport>, IAirportRepository
    {
        public AirportRepository(DbContextClass dbContext) : base(dbContext)
        {

        }
    }
}
