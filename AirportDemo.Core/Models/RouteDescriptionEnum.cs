using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportDemo.Core.Models
{
    public enum RouteDescriptionEnum
    {
        [Display(Name = "Arrival")]
        Arrival = 1,

        [Display(Name = "Departure")]
        Departure = 2
    }
}
