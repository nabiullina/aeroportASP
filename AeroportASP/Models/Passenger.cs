using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AeroportASP.Models
{
    public partial class Passenger
    {
        public Passenger()
        {
            PassInTrips = new HashSet<PassInTrip>();
        }

        [Display(Name = "Passeneger's id")]
        public int IdPsg { get; set; }
        [Display(Name = "Passeneger's name")]
        public string Name { get; set; } = null!;

        [Display(Name = "Passeneger's trips")]
        public virtual ICollection<PassInTrip> PassInTrips { get; set; }
    }
}
