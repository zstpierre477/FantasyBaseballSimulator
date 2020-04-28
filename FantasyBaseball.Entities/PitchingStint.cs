using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyBaseball.Entities
{
    public class PitchingStint
    {
        public int PitchingStintId { get; set; }
        
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        
        public int Year { get; set; }
        
        public int Stint { get; set; }
        
        public string TeamAbbreviation { get; set; }
        
        [ForeignKey("Team")]
        public int TeamId { get; set; }
        
        [ForeignKey("League")]
        public int LeagueId { get; set; }

        public League League { get; set; }
        
        public Team Team { get; set; }

        public Person Person { get; set; }

        public int Wins { get; set; }
        
        public int Losses { get; set; }
        
        public int Games { get; set; }
        
        public int GamesStarted { get; set; }
        
        public int CompleteGames { get; set; }
        
        public int Shutouts { get; set; }
        
        public int Saves { get; set; }
        
        public int InningsPitchedOuts { get; set; }
        
        public int Hits { get; set; }
        
        public int EarnedRuns { get; set; }
        
        public int HomeRuns { get; set; }
        
        public int Walks { get; set; }
        
        public int Strikeouts { get; set; }
        
        public double OpponentBattingAverage { get; set; }
        
        public double EarnedRunAverage { get; set; }
        
        public int IntentionalWalks { get; set; }
        
        public int WildPitches { get; set; }
        
        public int HitBatters { get; set; }
        
        public int Balks { get; set; }
        
        public int BattersFaced { get; set; }
        
        public int GamesFinished { get; set; }
        
        public int Runs { get; set; }
        
        public int SacrificeHits { get; set; }
        
        public int SacrificeFlies { get; set; }
        
        public int InducedDoublePlays { get; set; }
    }
}
