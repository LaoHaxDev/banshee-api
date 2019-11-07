using System;
using System.Collections.Generic;

namespace Banshee.Models
{
    public partial class Country
    {
        public Country()
        {
            State = new HashSet<State>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<State> State { get; set; }
    }
}
