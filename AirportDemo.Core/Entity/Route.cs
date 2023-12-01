namespace AirportDemo.Core.Entity
{
    public class Route
    {
        public long RouteID { get; set; }
        public long DepartureAirportGroupID { get; set; }
        public long ArrivalAirportGroupID { get; set; }
    }
}
