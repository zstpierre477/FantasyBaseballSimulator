using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyBaseball.Entities
{
    public class ManagerStint
    {
        public int ManagerStintId { get; set; }
        
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        
        public int Year { get; set; }
        
        public string TeamAbbreviation { get; set; }
        
        [ForeignKey("Team")]
        public int TeamId { get; set; }
        
        [ForeignKey("League")]
        public int LeagueId { get; set; }

        public League League { get; set; }
        
        public Team Team { get; set; }
        
        public Person Person { get; set; }

        public int InSeason { get; set; }
        
        public int Games { get; set; }
        
        public int Wins { get; set; }
        
        public int Losses { get; set; }
        
        public int TeamRank { get; set; }
        
        public bool PlayerManager { get; set; }
    }
}
