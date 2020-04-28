using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyBaseball.Entities
{
    public class Appearances
    {
        public int AppearancesId { get; set; }

        public int Year { get; set; }
        
        public string TeamAbbreviation { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }

        public Team Team { get; set; }
        
        [ForeignKey("League")]
        public int LeagueId { get; set; }

        public League League { get; set;; }

        [ForeignKey("Person")]
        public int PersonId { get; set; }

        public Person Person { get; set; }

        public int GamesPlayed { get; set; }
        
        public int GamesStarted { get; set; }
        
        public int GamesBatted { get; set; }
        
        public int GamesFielded { get; set; }
        
        public int GamesPitcher { get; set; }
        
        public int GamesCatcher { get; set; }
        
        public int GamesFirstBase { get; set; }
        
        public int GamesSecondBase { get; set; }
        
        public int GamesThirdBase { get; set; }
        
        public int GamesShortStop { get; set; }
        
        public int GamesLeftField { get; set; }
        
        public int GamesCenterField { get; set; }
        
        public int GamesRightField { get; set; }
        
        public int GamesOutfield { get; set; }
        
        public int GamesDesignatedHitter { get; set; }
        
        public int GamesPinchHitter { get; set; }
        
        public int GamesPinchRunner { get; set; }
    }
}
