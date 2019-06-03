using System;
using System.Collections.Generic;
using System.Text;

namespace CozyCo.Domain.Model
{
    public class Lease
    {
        public double Rent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // relation between Appuser and Lease
        public string TenantId { get; set; }
        public AppUser Tenant { get; set; }

        // relation between Property and Lease
        public int PropertyId { get; set; }
        public Property Property { get; set; }

    }
}
