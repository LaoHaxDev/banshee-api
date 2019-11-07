using System;
using System.Collections.Generic;

namespace Banshee.Models
{
    public partial class Visit
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public int SalesRepresentativeId { get; set; }
        public long Net { get; set; }
        public long VisitTotal { get; set; }
        public string Description { get; set; }

        public Client Client { get; set; }
        public SalesRepresentative SalesRepresentative { get; set; }
    }
}
