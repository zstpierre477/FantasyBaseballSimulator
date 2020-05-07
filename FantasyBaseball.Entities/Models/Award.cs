namespace FantasyBaseball.Entities.Models
{
    public partial class Award
    {
        public int AwardId { get; set; }
        public int PersonId { get; set; }
        public string AwardName { get; set; }
        public short Year { get; set; }
        public int LeagueId { get; set; }
        public bool? Tie { get; set; }
        public string Notes { get; set; }

        public virtual League League { get; set; }
        public virtual Person Person { get; set; }
    }
}
