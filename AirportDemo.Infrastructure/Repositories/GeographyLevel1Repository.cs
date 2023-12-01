using AirportDemo.Core.Entity;
using AirportDemo.Core.Interfaces;

namespace AirportDemo.Infrastructure.Repositories
{
    public class GeographyLevel1Repository : GenericRepository<GeographyLevel1>, IGeographyLevel1Repository
    {
        public GeographyLevel1Repository(DbContextClass dbContext) : base(dbContext)
        {

        }
    }
}
