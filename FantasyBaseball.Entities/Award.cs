using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyBaseball.Entities
{
    public class Award
    {
        public int AwardId { get; set; }
        
        [ForeignKey("Person")]
        public int PersonId { get; set; }

        public Person Person { get; set; }
        
        public string AwardName { get; set; }
        
        public int Year { get; set; }

        [ForeignKey("League")]
        public int LeagueId { get; set; }

        public League League { get; set; }
        
        public bool Tie { get; set; }
        
        public string Notes { get; set; }
    }
}
