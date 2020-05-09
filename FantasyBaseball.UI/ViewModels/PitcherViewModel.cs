using FantasyBaseball.Entities.Models;
using System;

namespace FantasyBaseball.UI.ViewModels
{
    public class PitcherViewModel : IPlayerViewModel
    {
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
                
        public short HitBatters { get; set; }
                
        public double IP => Math.Round((double)InningsPitchedOuts / 3, 1);

        public double AverageIP => IP / Games;

        public double WHIP => IP > 0 ? Math.Round(((Walks + Hits + HitBatters) / IP), 2) : 0;

        public PlayerStint PlayerStint { get; set; }

        public PitcherViewModel(PlayerStint playerStint)
        {
            PlayerStint = playerStint;
            FirstName = playerStint.Person.FirstName;
            LastName = playerStint.Person.LastName;
            Year = playerStint.PitchingStint.Year;
            TeamShortName = playerStint.Team.TeamIdBr;
            Wins = playerStint.PitchingStint.Wins ?? 0;
            Losses = playerStint.PitchingStint.Losses ?? 0;
            Games = playerStint.PitchingStint.Games ?? 0;
            GamesStarted = playerStint.PitchingStint.GamesStarted ?? 0;
            Saves = playerStint.PitchingStint.Saves ?? 0;
            InningsPitchedOuts = playerStint.PitchingStint.InningsPitchedOuts ?? 0;
            Hits = playerStint.PitchingStint.Hits ?? 0;
            EarnedRuns = playerStint.PitchingStint.EarnedRuns ?? 0;
            HomeRuns = playerStint.PitchingStint.HomeRuns ?? 0;
            Walks = playerStint.PitchingStint.Walks ?? 0;
            Strikeouts = playerStint.PitchingStint.Strikeouts ?? 0;
            OpponentBattingAverage = playerStint.PitchingStint.OpponentBattingAverage ?? .000;
            EarnedRunAverage = playerStint.PitchingStint.EarnedRunAverage ?? .000;
            HitBatters = playerStint.PitchingStint.HitBatters ?? 0;
        }

        public int CurrentGameStrikeouts { get; set; }

        public int CurrentGameWalks { get; set; }

        public int CurrentGameHits { get; set; }

        public int CurrentGameRuns { get; set; }

        public int CurrentGameEarnedRuns { get; set; }

        public double CurrentGameInningsPitched { get; set; }

        public bool CurrentGameIsTired => CurrentGameInningsPitched > Math.Round(AverageIP, 0, MidpointRounding.ToPositiveInfinity);
    }
}
