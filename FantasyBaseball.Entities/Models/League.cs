using System.Collections.Generic;

namespace FantasyBaseball.Entities.Models
{
    public partial class League
    {
        public League()
        {
            AllStar = new HashSet<AllStar>();
            Appearances = new HashSet<Appearances>();
            Award = new HashSet<Award>();
            AwardVoting = new HashSet<AwardVoting>();
            BattingPostseasonRound = new HashSet<BattingPostseasonRound>();
            BattingStint = new HashSet<BattingStint>();
            Division = new HashSet<Division>();
            FieldingPostseasonRound = new HashSet<FieldingPostseasonRound>();
            FieldingStint = new HashSet<FieldingStint>();
            ManagerStint = new HashSet<ManagerStint>();
            ParkStint = new HashSet<ParkStint>();
            PitchingPostseasonRound = new HashSet<PitchingPostseasonRound>();
            PitchingStint = new HashSet<PitchingStint>();
            PostseasonSeriesLosingTeamLeague = new HashSet<PostseasonSeries>();
            PostseasonSeriesWinningTeamLeague = new HashSet<PostseasonSeries>();
            Salary = new HashSet<Salary>();
            Team = new HashSet<Team>();
        }

        public int LeagueId { get; set; }
        public string LeagueAbbreviation { get; set; }
        public string LeagueName { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<AllStar> AllStar { get; set; }
        public virtual ICollection<Appearances> Appearances { get; set; }
        public virtual ICollection<Award> Award { get; set; }
        public virtual ICollection<AwardVoting> AwardVoting { get; set; }
        public virtual ICollection<BattingPostseasonRound> BattingPostseasonRound { get; set; }
        public virtual ICollection<BattingStint> BattingStint { get; set; }
        public virtual ICollection<Division> Division { get; set; }
        public virtual ICollection<FieldingPostseasonRound> FieldingPostseasonRound { get; set; }
        public virtual ICollection<FieldingStint> FieldingStint { get; set; }
        public virtual ICollection<ManagerStint> ManagerStint { get; set; }
        public virtual ICollection<ParkStint> ParkStint { get; set; }
        public virtual ICollection<PitchingPostseasonRound> PitchingPostseasonRound { get; set; }
        public virtual ICollection<PitchingStint> PitchingStint { get; set; }
        public virtual ICollection<PostseasonSeries> PostseasonSeriesLosingTeamLeague { get; set; }
        public virtual ICollection<PostseasonSeries> PostseasonSeriesWinningTeamLeague { get; set; }
        public virtual ICollection<Salary> Salary { get; set; }
        public virtual ICollection<Team> Team { get; set; }
    }
}
