using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportDemo.Core.Models
{
    public class GeographyLevel1Dto
    {
         
        [Required]
        public string Name { get; set; } = string.Empty; 
    }
}
