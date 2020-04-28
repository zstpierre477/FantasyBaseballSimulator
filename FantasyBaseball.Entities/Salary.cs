using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyBaseball.Entities
{
    public class Salary
    {
        public int SalaryId { get; set; }
        
        public int Year { get; set; }
        
        public string TeamAbbreviation { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }
        
        [ForeignKey("League")]
        public int LeagueId { get; set; }

        [ForeignKey("Person")]
        public int PersonId { get; set; }

        public League League { get; set; }
        
        public Team Team { get; set; }

        public Person Person { get; set; }

        public double SalaryAmount { get; set; }
    }
}
