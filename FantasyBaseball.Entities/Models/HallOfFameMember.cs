namespace FantasyBaseball.Entities.Models
{
    public partial class HallOfFameMember
    {
        public int HallOfFameMemberId { get; set; }
        public int PersonId { get; set; }
        public short Year { get; set; }
        public string VotedBy { get; set; }
        public short? Ballots { get; set; }
        public short? Needed { get; set; }
        public short? Votes { get; set; }
        public bool? Inducted { get; set; }
        public string Category { get; set; }
        public string NeededNote { get; set; }

        public virtual Person Person { get; set; }
    }
}
