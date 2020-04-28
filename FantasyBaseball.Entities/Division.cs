using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyBaseball.Entities
{
    public class Division
    {
        public int DivisionId { get; set; }
        
        public string DivisionAbbreviation { get; set; }
        
        [ForeignKey("League")]
        public int LeagueId { get; set; }

        public League League { get; set; }

        public string DivisionName { get; set; }
        
        public bool Active { get; set; }
    }
}
