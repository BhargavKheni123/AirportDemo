using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportDemo.Core.Entity;
using AirportDemo.Core.Interfaces;

namespace AirportDemo.Infrastructure.Repositories
{
    internal class AirportGroupRepository : GenericRepository<AirportGroup>, IAirportGroupRepository
    {
        public AirportGroupRepository(DbContextClass dbContext) : base(dbContext)
        {

        }
    }
}
