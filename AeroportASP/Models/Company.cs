using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AeroportASP.Models
{
    public partial class Company
    {
        public Company()
        {
            Trips = new HashSet<Trip>();
        }
        [DisplayName("Company's id")]
        public int IdComp { get; set; }
        [DisplayName("Company's name")]
        public string Name { get; set; } = null!;
        [DisplayName("Company's trips")]
        public virtual ICollection<Trip> Trips { get; set; }
    }
}
