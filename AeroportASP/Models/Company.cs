using System;
using System.Collections.Generic;

namespace AeroportASP.Models
{
    public partial class Company
    {
        public Company()
        {
            Trips = new HashSet<Trip>();
        }

        public int IdComp { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Trip> Trips { get; set; }
    }
}
