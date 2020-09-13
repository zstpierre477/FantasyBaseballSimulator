using System;
using System.Collections.Generic;

namespace FantasyBaseball.Entities.Models
{
    public partial class Franchise
    {
        public Franchise()
        {
            Team = new HashSet<Team>();
        }

        public int FranchiseId { get; set; }
        public string FranchiseAbbreviation { get; set; }
        public string FranchiseName { get; set; }
        public bool? Active { get; set; }
        public string NationalAssociation { get; set; }

        public virtual ICollection<Team> Team { get; set; }
    }
}
