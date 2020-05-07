using System.Collections.Generic;

namespace FantasyBaseball.Entities.Models
{
    public partial class Team
    {
        public Team()
        {
            AllStar = new HashSet<AllStar>();
            Appearances = new HashSet<Appearances>();
            BattingPostseasonRound = new HashSet<BattingPostseasonRound>();
            BattingStint = new HashSet<BattingStint>();
            FieldingPostseasonRound = new HashSet<FieldingPostseasonRound>();
            FieldingStint = new HashSet<FieldingStint>();
            ManagerStint = new HashSet<ManagerStint>();
            ParkStint = new HashSet<ParkStint>();
            PitchingPostseasonRound = new HashSet<PitchingPostseasonRound>();
            PitchingStint = new HashSet<PitchingStint>();
            PostseasonSeriesLosingTeam = new HashSet<PostseasonSeries>();
            PostseasonSeriesWinningTeam = new HashSet<PostseasonSeries>();
            Salary = new HashSet<Salary>();
        }

        public int TeamId { get; set; }
        public short Year { get; set; }
        public int? LeagueId { get; set; }
        public string TeamAbbreviation { get; set; }
        public int? FranchiseId { get; set; }
        public string DivisionAbbreviation { get; set; }
        public int? DivisionId { get; set; }
        public short? TeamRank { get; set; }
        public short? Games { get; set; }
        public short? HomeGames { get; set; }
        public short? Wins { get; set; }
        public short? Losses { get; set; }
        public bool? WonDivision { get; set; }
        public bool? WonWildCard { get; set; }
        public bool? WonLeague { get; set; }
        public bool? WonWorldSeries { get; set; }
        public short? Runs { get; set; }
        public short? AtBats { get; set; }
        public short? Hits { get; set; }
        public short? Doubles { get; set; }
        public short? Triples { get; set; }
        public short? HomeRuns { get; set; }
        public short? Walks { get; set; }
        public short? Strikeouts { get; set; }
        public short? StolenBases { get; set; }
        public short? CaughtStealing { get; set; }
        public short? HitByPitch { get; set; }
        public short? SacrificeFlies { get; set; }
        public short? RunsAllowed { get; set; }
        public short? EarnedRuns { get; set; }
        public double? EarnedRunAverage { get; set; }
        public short? CompleteGames { get; set; }
        public short? Shutouts { get; set; }
        public short? Saves { get; set; }
        public int? InningsPitchedOuts { get; set; }
        public short? HitsAllowed { get; set; }
        public short? HomeRunsAllowed { get; set; }
        public short? WalksAllowed { get; set; }
        public short? StrikeoutsPitched { get; set; }
        public int? Errors { get; set; }
        public int? DoublePlays { get; set; }
        public double? Fp { get; set; }
        public string Name { get; set; }
        public string Park { get; set; }
        public int? Attendance { get; set; }
        public int? Bpf { get; set; }
        public int? Ppf { get; set; }
        public string TeamIdBr { get; set; }
        public string TeamIdLahman45 { get; set; }
        public string TeamIdRetro { get; set; }

        public virtual Division Division { get; set; }
        public virtual Franchise Franchise { get; set; }
        public virtual League League { get; set; }
        public virtual ICollection<AllStar> AllStar { get; set; }
        public virtual ICollection<Appearances> Appearances { get; set; }
        public virtual ICollection<BattingPostseasonRound> BattingPostseasonRound { get; set; }
        public virtual ICollection<BattingStint> BattingStint { get; set; }
        public virtual ICollection<FieldingPostseasonRound> FieldingPostseasonRound { get; set; }
        public virtual ICollection<FieldingStint> FieldingStint { get; set; }
        public virtual ICollection<ManagerStint> ManagerStint { get; set; }
        public virtual ICollection<ParkStint> ParkStint { get; set; }
        public virtual ICollection<PitchingPostseasonRound> PitchingPostseasonRound { get; set; }
        public virtual ICollection<PitchingStint> PitchingStint { get; set; }
        public virtual ICollection<PostseasonSeries> PostseasonSeriesLosingTeam { get; set; }
        public virtual ICollection<PostseasonSeries> PostseasonSeriesWinningTeam { get; set; }
        public virtual ICollection<Salary> Salary { get; set; }
    }
}
