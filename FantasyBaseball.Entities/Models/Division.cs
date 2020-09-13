using System;
using System.Collections.Generic;

namespace FantasyBaseball.Entities.Models
{
    public partial class Division
    {
        public Division()
        {
            Team = new HashSet<Team>();
        }

        public int DivisionId { get; set; }
        public string DivisionAbbreviation { get; set; }
        public int LeagueId { get; set; }
        public string DivisionName { get; set; }
        public bool Active { get; set; }

        public virtual League League { get; set; }
        public virtual ICollection<Team> Team { get; set; }
    }
}
