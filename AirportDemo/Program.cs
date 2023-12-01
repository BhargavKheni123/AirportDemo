using AirportDemo.Helper;
using AirportDemo.Infrastructure.ServiceExtension;
using AirportDemo.Services;
using AirportDemo.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDIServices(builder.Configuration);
builder.Services.AddScoped<IGeographyLevel1Service, GeographyLevel1Service>();
builder.Services.AddScoped<IAirportService, AirportService>();
builder.Services.AddScoped<IRouteService, RouteService>();
builder.Services.AddScoped<IAirportGroupService, AirportGroupService>();
 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
 