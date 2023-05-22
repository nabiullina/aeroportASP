using System;
using System.Collections.Generic;

namespace AeroportASP.Models
{
    public partial class PassInTrip
    {
        public int TripNo { get; set; }
        public DateTime Date { get; set; }
        public int IdPsg { get; set; }
        public string Place { get; set; } = null!;

        public virtual Passenger IdPsgNavigation { get; set; } = null!;
        public virtual Trip TripNoNavigation { get; set; } = null!;
    }
}
