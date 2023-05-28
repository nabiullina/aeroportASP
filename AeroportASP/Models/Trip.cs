using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AeroportASP.Models
{
    public partial class Trip
    {
        public Trip()
        {
            PassInTrips = new HashSet<PassInTrip>();
        }

        [DisplayName("Trip's number")]
        public int TripNo { get; set; }
        
        [DisplayName("Company's id")]
        public int IdComp { get; set; }
        
        [DisplayName("Plane")]
        public string Plane { get; set; } = null!;
        
        [DisplayName("Departure city")]
        public string TownFrom { get; set; } = null!;
        
        [DisplayName("Arrival city")]
        public string TownTo { get; set; } = null!;
        
        [DisplayName("Departure time")]
        public DateTime TimeOut { get; set; }
        
        [DisplayName("Arrival time")]
        public DateTime TimeIn { get; set; }

        [DisplayName("Company")]
        public virtual Company IdCompNavigation { get; set; } = null!;
        
        [DisplayName("Passengers")]
        public virtual ICollection<PassInTrip> PassInTrips { get; set; }
    }
}
