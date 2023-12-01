using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportDemo.Core.Entity
{
    public class AirportGroup
    {
        public int AirportGroupID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string AirtportIds { get; set; } = string.Empty;
    }
}
