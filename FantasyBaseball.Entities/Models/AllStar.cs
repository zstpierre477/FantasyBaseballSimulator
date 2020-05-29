namespace FantasyBaseball.Entities.Models
{
    public partial class AllStar
    {
        public int AllStarId { get; set; }
        public int PersonId { get; set; }
        public short Year { get; set; }
        public short GameNumber { get; set; }
        public string GameId { get; set; }
        public string TeamAbbreviation { get; set; }
        public int? TeamId { get; set; }
        public int? LeagueId { get; set; }
        public short? GamesPlayed { get; set; }
        public short? StartingPositionId { get; set; }

        public virtual League League { get; set; }
        public virtual Person Person { get; set; }
        public virtual Team Team { get; set; }
    }
}
