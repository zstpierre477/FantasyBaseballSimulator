using System;
using System.Collections.Generic;

namespace FantasyBaseball.Entities.Models
{
    public partial class Appearances
    {
        public int AppearancesId { get; set; }
        public short Year { get; set; }
        public string TeamAbbreviation { get; set; }
        public int? TeamId { get; set; }
        public int? LeagueId { get; set; }
        public int PersonId { get; set; }
        public short? Games { get; set; }
        public short? GamesStarted { get; set; }
        public short? GamesBatted { get; set; }
        public short? GamesFielded { get; set; }
        public short? GamesPitcher { get; set; }
        public short? GamesCatcher { get; set; }
        public short? GamesFirstBase { get; set; }
        public short? GamesSecondBase { get; set; }
        public short? GamesThirdBase { get; set; }
        public short? GamesShortStop { get; set; }
        public short? GamesLeftfield { get; set; }
        public short? GamesCenterfield { get; set; }
        public short? GamesRightfield { get; set; }
        public short? GamesOutfield { get; set; }
        public short? GamesDesignatedHitter { get; set; }
        public short? GamesPinchHitter { get; set; }
        public short? GamesPinchRunner { get; set; }

        public virtual League League { get; set; }
        public virtual Person Person { get; set; }
        public virtual Team Team { get; set; }
    }
}
