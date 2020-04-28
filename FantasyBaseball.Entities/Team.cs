using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyBaseball.Entities
{
    public class Team
    {
        public int TeamId { get; set; }
        
        public int Year { get; set; }
        
        [ForeignKey("League")]
        public int LeagueId { get; set; }
        
        public string TeamAbbreviation { get; set; }
        
        [ForeignKey("Franchise")]
        public int FranchiseId { get; set; }
        
        public string DivisionAbbreviation { get; set; }

        [ForeignKey("Division")]
        public int DivisionId { get; set; }

        public League League { get; set; }
        
        public Franchise Franchise { get; set; }

        public Division Division { get; set; }

        public int TeamRank { get; set; }
        
        public int Games { get; set; }
        
        public int HomeGames { get; set; }
        
        public int Wins { get; set; }
        
        public int Losses { get; set; }
        
        public bool WonDivision { get; set; }
        
        public bool WonWildCard { get; set; }
        
        public bool WonLeague { get; set; }
        
        public bool WonWorldSeries { get; set; }
        
        public int Runs { get; set; }
        
        public int AtBats { get; set; }
        
        public int Hits { get; set; }
        
        public int Doubles { get; set; }
        
        public int Triples { get; set; }
        
        public int HomeRuns { get; set; }
        
        public int Walks { get; set; }
        
        public int Strikeouts { get; set; }
        
        public int StolenBases { get; set; }
        
        public int CaughtStealing { get; set; }
        
        public int HitByPitch { get; set; }
        
        public int SacrificeFlies { get; set; }
        
        public int RunsAllowed { get; set; }
        
        public int EarnedRuns { get; set; }
        
        public double EarnedRunAverage { get; set; }
        
        public int CompleteGames { get; set; }
        
        public int Shutouts { get; set; }
        
        public int Saves { get; set; }
        
        public int IPouts { get; set; }
        
        public int HitsAllowed { get; set; }
        
        public int HomeRunsAllowed { get; set; }
        
        public int WalksAllowed { get; set; }
        
        public int StrikeoutsPitched { get; set; }
        
        public int Errors { get; set; }
        
        public int DoublePplays { get; set; }
        
        public double FP { get; set; }
        
        public string Name { get; set; }
        
        public string Park { get; set; }
        
        public int Attendance { get; set; }
        
        public int BPF { get; set; }
        
        public int PPF { get; set; }
        
        public string TeamIdBR { get; set; }
        
        public string TeamIdLahman45 { get; set; }
        
        public string TeamIdRetro { get; set; }
    }
}
