using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportDemo.Core.Models
{
    public class RouteDto
    {
        public long RouteId { get; set; }
        public long ArrivalAirportGroupID { get; set; }
        public string ArrivalAirportId { get; set; }
        public long DepartureAirportGroupID { get; set; }
        public string DepartureAirportId { get;set; }

    }

    public class RouteInputDto
    {
        public long ArrivalAirportGroupID { get; set; }
        public long DepartureAirportGroupID { get; set; }
    }

}
