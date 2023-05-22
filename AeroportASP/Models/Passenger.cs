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

        [Display(Name = "Passeneger ID")]
        public int IdPsg { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<PassInTrip> PassInTrips { get; set; }
    }
}
