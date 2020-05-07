namespace FantasyBaseball.Entities.Models
{
    public partial class FieldingOutfieldStint
    {
        public int FieldingOutfieldStintId { get; set; }
        public int PersonId { get; set; }
        public short Year { get; set; }
        public short Stint { get; set; }
        public short? GamesLeftfield { get; set; }
        public short? GamesCenterField { get; set; }
        public short? GamesRightField { get; set; }

        public virtual Person Person { get; set; }
    }
}
