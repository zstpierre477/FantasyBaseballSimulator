using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyBaseball.Entities
{
    public class BattingPostseasonRound
    {
        public int BattingPostseasonRoundId { get; set; }

        public int Year { get; set; }

        public string Round { get; set; }

        [ForeignKey("Person")]
        public int PersonId { get; set; }
              
        public string TeamAbbreviation { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }

        [ForeignKey("League")]
        public int LeagueId { get; set; }

        public League League { get; set; }
        
        public Team Team { get; set; }
        
        public Person Person { get; set; }

        public int Games { get; set; }
                
        public int AtBats { get; set; }
        
        public int Runs { get; set; }
        
        public int Hits { get; set; }
        
        public int Doubles { get; set; }
        
        public int Triples { get; set; }
        
        public int HomeRuns { get; set; }
        
        public int RunsBattedIn { get; set; }
        
        public int StolenBases { get; set; }
        
        public int CaughtStealing { get; set; }
        
        public int Walks { get; set; }
        
        public int Strikeouts { get; set; }
        
        public int IntentionalWalks { get; set; }
        
        public int HitByPitch { get; set; }
        
        public int SacrificeHits { get; set; }
        
        public int SacrificeFlies { get; set; }
        
        public int GroundedIntoDoublePlays { get; set; }    
    }
}
