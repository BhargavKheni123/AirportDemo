

namespace AirportDemo.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGeographyLevel1Repository GeographyLevel1 { get; }
        IAirportRepository Airport { get; }
        IRouteRepository Route { get; }
        IAirportGroupRepository AirportGroup { get; }

        int Save();
    }
}
