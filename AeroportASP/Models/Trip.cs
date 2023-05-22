using System;
using System.Collections.Generic;

namespace AeroportASP.Models
{
    public partial class Trip
    {
        public Trip()
        {
            PassInTrips = new HashSet<PassInTrip>();
        }

        public int TripNo { get; set; }
        public int IdComp { get; set; }
        public string Plane { get; set; } = null!;
        public string TownFrom { get; set; } = null!;
        public string TownTo { get; set; } = null!;
        public DateTime TimeOut { get; set; }
        public DateTime TimeIn { get; set; }

        public virtual Company IdCompNavigation { get; set; } = null!;
        public virtual ICollection<PassInTrip> PassInTrips { get; set; }
    }
}
