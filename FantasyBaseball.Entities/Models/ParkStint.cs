namespace FantasyBaseball.Entities.Models
{
    public partial class ParkStint
    {
        public int ParkStintId { get; set; }
        public int? Year { get; set; }
        public int? LeagueId { get; set; }
        public string TeamAbbreviation { get; set; }
        public int? TeamId { get; set; }
        public string ParkKey { get; set; }
        public int? ParkId { get; set; }
        public string SpanFirst { get; set; }
        public string SpanLast { get; set; }
        public int? Games { get; set; }
        public int? Openings { get; set; }
        public int? Attendance { get; set; }
        public DateTime? SpanFirstDate { get; set; }
        public DateTime? SpanLastDate { get; set; }

        public virtual League League { get; set; }
        public virtual Park Park { get; set; }
        public virtual Team Team { get; set; }
    }
}
