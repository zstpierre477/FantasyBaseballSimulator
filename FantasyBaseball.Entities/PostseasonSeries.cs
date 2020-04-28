using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyBaseball.Entities
{
    public class PostseasonSeries
    {
        public int PostseasonSeriesId { get; set; }

        public int Year { get; set; }

        public string Round { get; set; }

        public string WinningTeamAbbreviation { get; set; }

        [ForeignKey("League")]
        public int WinningTeamLeagueId { get; set; }

        [ForeignKey("Team")]
        public int WinningTeamId { get; set; }

        public string LosingTeamAbbreviation { get; set; }

        [ForeignKey("Team")]
        public int LosingTeamId { get; set; }

        [ForeignKey("League")]
        public int LosingTeamLeagueId { get; set; }

        public League WinningTeamLeague { get; set; }

        public Team WinningTeam { get; set; }

        public League LosingTeamLeague { get; set; }

        public Team LosingTeam { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public int Ties { get; set; }
    }
}
