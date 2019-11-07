using System;
using System.Collections.Generic;

namespace Banshee.Models
{
    public partial class Client
    {
        public Client()
        {
            Visit = new HashSet<Visit>();
        }

        public int Id { get; set; }
        public string Nit { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int CityId { get; set; }
        public long CreditLimit { get; set; }
        public long AvailableCredit { get; set; }
        public float VisitsPercentage { get; set; }

        public City City { get; set; }
        public ICollection<Visit> Visit { get; set; }
    }
}
