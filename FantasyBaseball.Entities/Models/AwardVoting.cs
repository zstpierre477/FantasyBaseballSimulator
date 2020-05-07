namespace FantasyBaseball.Entities.Models
{
    public partial class AwardVoting
    {
        public int AwardVotingId { get; set; }
        public string AwardName { get; set; }
        public short Year { get; set; }
        public int LeagueId { get; set; }
        public int PersonId { get; set; }
        public short? PointsWon { get; set; }
        public short? PointsMax { get; set; }
        public short? VotesFirst { get; set; }

        public virtual League League { get; set; }
        public virtual Person Person { get; set; }
    }
}
