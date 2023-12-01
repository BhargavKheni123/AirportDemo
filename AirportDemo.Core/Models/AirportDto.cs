using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportDemo.Core.Models
{
    public class AirportDto
    {
        public long AirportID { get; set; }
        public string IATACode { get; set; } = string.Empty;
    }
}
