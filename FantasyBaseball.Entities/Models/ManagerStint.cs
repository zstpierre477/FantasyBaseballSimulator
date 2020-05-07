namespace FantasyBaseball.Entities.Models
{
    public partial class ManagerStint
    {
        public int ManagerStintId { get; set; }
        public int? PersonId { get; set; }
        public short Year { get; set; }
        public string TeamAbbreviation { get; set; }
        public int? TeamId { get; set; }
        public int? LeagueId { get; set; }
        public short InSeason { get; set; }
        public short? Games { get; set; }
        public short? Wins { get; set; }
        public short? Losses { get; set; }
        public short? TeamRank { get; set; }
        public bool? PlayerManager { get; set; }

        public virtual League League { get; set; }
        public virtual Person Person { get; set; }
        public virtual Team Team { get; set; }
    }
}
