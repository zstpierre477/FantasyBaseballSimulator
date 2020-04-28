namespace FantasyBaseball.Entities
{
    public class Franchise
    {
        public int FranchiseId { get; set; }

        public string FranchiseAbbreviation { get; set; }
        
        public string FranchiseName { get; set; }
        
        public bool Active { get; set; }
        
        public string NationalAssociation { get; set; }
    }
}
