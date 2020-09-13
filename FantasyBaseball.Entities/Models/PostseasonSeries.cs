using System;
using System.Collections.Generic;

namespace FantasyBaseball.Entities.Models
{
    public partial class PostseasonSeries
    {
        public int PostseasonSeriesId { get; set; }
        public short Year { get; set; }
        public string Round { get; set; }
        public string WinningTeamAbbreviation { get; set; }
        public int? WinningTeamLeagueId { get; set; }
        public int? WinningTeamId { get; set; }
        public string LosingTeamAbbreviation { get; set; }
        public int? LosingTeamId { get; set; }
        public int? LosingTeamLeagueId { get; set; }
        public short? Wins { get; set; }
        public short? Losses { get; set; }
        public short? Ties { get; set; }

        public virtual Team LosingTeam { get; set; }
        public virtual League LosingTeamLeague { get; set; }
        public virtual Team WinningTeam { get; set; }
        public virtual League WinningTeamLeague { get; set; }
    }
}
