namespace FantasyBaseball.Entities
{
    public class League
    {
        public int LeagueId { get; set; }

        public string LeagueAbbreviation { get; set; }
        
        public string LeagueName { get; set; }
        
        public bool Active { get; set; }
    }
}
