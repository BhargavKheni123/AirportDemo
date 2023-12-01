using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AirportDemo.Core.Interfaces;
using AirportDemo.Infrastructure.Repositories;

namespace AirportDemo.Infrastructure.ServiceExtension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContextClass>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAirportRepository, AirportRepository>();
            services.AddScoped<IGeographyLevel1Repository, GeographyLevel1Repository>();
            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<IAirportGroupRepository, AirportGroupRepository>();
            //services.AddAutoMapper(typeof(AutoMapperProfiles));

            return services;
        }
    }
}
