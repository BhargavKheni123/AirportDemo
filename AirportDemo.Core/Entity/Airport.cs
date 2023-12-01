using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportDemo.Core.Entity
{
    public class Airport
    {
        public long AirportID { get; set; }
        public string IATACode { get; set; }
        public int GeographyLevel1ID { get; set; }
        public string Type { get; set; }
    }
}
