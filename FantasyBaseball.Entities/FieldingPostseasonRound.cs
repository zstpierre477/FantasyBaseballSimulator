using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyBaseball.Entities
{
    public class FieldingPostseasonRound
    {
        public int FieldingPostseasonRoundId { get; set; }

        [ForeignKey("Person")]
        public int PersonId { get; set; }

        public int Year { get; set; }

        public string TeamAbbreviation { get; set; }

        [ForeignKey("Team")]
        public int TeamID { get; set; }

        [ForeignKey("League")]
        public int LeagueID { get; set; }

        public League League { get; set; }
        
        public Team Team { get; set; }
        
        public Person Person { get; set; }

        public string Round { get; set; }

        public string Position { get; set; }
        
        public int Games { get; set; }
        
        public int GamesStarted { get; set; }
        
        public int InningsPlayedOuts { get; set; }
        
        public int Putouts { get; set; }
        
        public int Assists { get; set; }
        
        public int Errors { get; set; }
        
        public int DoublePlays { get; set; }
        
        public int PassedBalls { get; set; }
        
        public int WildPitches { get; set; }
        
        public int StolenBasesAgainst { get; set; }
        
        public int RunnersThrownOut { get; set; }
    }
}
