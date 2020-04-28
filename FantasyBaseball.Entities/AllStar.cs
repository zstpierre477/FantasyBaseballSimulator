using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyBaseball.Entities
{
    public class AllStar
    {
        public int AllStarId { get; set; }

        [ForeignKey("Person")]
        public int PersonId { get; set; }

        public Person Person { get; set; }

        public int Year { get; set; }

        public int GameNumber { get; set; }

        public string GameId { get; set; }

        public string TeamAbbreviation { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }

        public Team Team { get; set; }

        [ForeignKey("League")]
        public int LeagueId { get; set; }

        public League League { get; set; }

        public int GamesPlayed { get; set; }

        public int StartingPositionID { get; set; }
    }
}
