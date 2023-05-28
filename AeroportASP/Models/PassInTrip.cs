using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AeroportASP.Models
{
    public partial class PassInTrip
    {
        [DisplayName("Trip's number")]
        public int TripNo { get; set; }
        [DisplayName("Trip's date")]
        public DateTime Date { get; set; }
        [DisplayName("Passenger's id")]
        public int IdPsg { get; set; }
        [DisplayName("Place")]
        public string Place { get; set; } = null!;
        [DisplayName("Passenger")]
        public virtual Passenger? IdPsgNavigation { get; set; } = null!;
        [DisplayName("Trip")]
        public virtual Trip? TripNoNavigation { get; set; } = null!;
    }
}
