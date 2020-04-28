using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyBaseball.Entities
{
    public class AwardVoting
    {
        public int AwardVotingId { get; set; }
                
        public string AwardName { get; set; }
        
        public int Year { get; set; }

        [ForeignKey("League")]
        public int LeagueId { get; set; }

        public League League { get; set; }

        [ForeignKey("Person")]
        public int PersonId { get; set; }

        public Person Person { get; set; }

        public int PointsWon { get; set; }

        public int PointsMax { get; set; }

        public int VotesFirst { get; set; }
    }
}
