using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportDemo.Core.Interfaces;

namespace AirportDemo.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextClass _dbContext;
        public IGeographyLevel1Repository GeographyLevel1 { get; }
        public IAirportRepository Airport { get; }
        public IRouteRepository Route { get; }
        public IAirportGroupRepository AirportGroup { get; }

        public UnitOfWork(DbContextClass dbContext,
                            IGeographyLevel1Repository geographyLevel1,
                            IAirportRepository airport,
                            IRouteRepository route,
                            IAirportGroupRepository airportGroup)
        {
            _dbContext = dbContext;
            GeographyLevel1 = geographyLevel1;
            Airport = airport;
            Route = route;
            AirportGroup = airportGroup;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

    }
}
