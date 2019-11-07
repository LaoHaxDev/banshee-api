using System;
using System.Collections.Generic;

namespace Banshee.Models
{
    public partial class SalesRepresentative
    {
        public SalesRepresentative()
        {
            Visit = new HashSet<Visit>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Visit> Visit { get; set; }
    }
}
