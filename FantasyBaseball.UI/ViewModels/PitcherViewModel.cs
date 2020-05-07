using FantasyBaseball.Entities.Models;
using System;

namespace FantasyBaseball.UI.ViewModels
{
    public class PitcherViewModel : IPlayerViewModel
    {
        public int StintId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public short Year { get; set; }

        public string TeamShortName { get; set; }

        public short Wins { get; set; }
        
        public short Losses { get; set; }
        
        public short Games { get; set; }
        
        public short GamesStarted { get; set; }
                
        public short Saves { get; set; }
        
        public int InningsPitchedOuts { get; set; }
        
        public short Hits { get; set; }
        
        public short EarnedRuns { get; set; }
        
        public short HomeRuns { get; set; }
        
        public short Walks { get; set; }
        
        public short Strikeouts { get; set; }
        
        public double OpponentBattingAverage { get; set; }
        
        public double EarnedRunAverage { get; set; }
                
        public short WildPitches { get; set; }
        
        public short HitBatters { get; set; }
        
        public short Balks { get; set; }
        
        public short BattersFaced { get; set; }
                                
        public short SacrificeFlies { get; set; }
        
        public short InducedDoublePlays { get; set; }

        public double IP => Math.Round((double)InningsPitchedOuts / 3, 1);

        public double WHIP => IP > 0 ? Math.Round(((Walks + Hits + HitBatters) / IP), 2) : 0;

        public PlayerStint PlayerStint { get; set; }

        public PitcherViewModel(PlayerStint playerStint)
        {
            throw new NotImplementedException();
        }
    }
}
