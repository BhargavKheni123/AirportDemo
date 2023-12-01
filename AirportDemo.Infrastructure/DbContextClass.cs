using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportDemo.Core.Entity;
using AirportDemo.Core.Models;

namespace AirportDemo.Infrastructure
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> contextOptions) : base(contextOptions)
        {

        }

        public DbSet<Route> Route { get; set; }
        public DbSet<GeographyLevel1> GeographyLevel1 { get; set; }
        public DbSet<Airport> Airport { get; set; }
        public DbSet<AirportGroup> AirportGroup { get; set; }
    }
}
