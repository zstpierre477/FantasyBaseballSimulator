namespace FantasyBaseball.Entities.Models
{
    public partial class Salary
    {
        public int SalaryId { get; set; }
        public short Year { get; set; }
        public string TeamAbbreviation { get; set; }
        public int? TeamId { get; set; }
        public int LeagueId { get; set; }
        public int PersonId { get; set; }
        public double? SalaryAmount { get; set; }

        public virtual League League { get; set; }
        public virtual Person Person { get; set; }
        public virtual Team Team { get; set; }
    }
}
