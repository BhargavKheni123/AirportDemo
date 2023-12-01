using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportDemo.Core.Entity;
using AirportDemo.Core.Interfaces;

namespace AirportDemo.Infrastructure.Repositories
{
    public class RouteRepository : GenericRepository<Route>, IRouteRepository
    {
        public RouteRepository(DbContextClass dbContext) : base(dbContext)
        {

        }
    }
}
