using FantasyBaseball.Entities.Models;

namespace FantasyBaseball.Entities.Helpers
{
    public static class BattingStintHelperFunctions
    {
        public static BattingStint CreateBattingStintForNonBatter()
        {
            return new BattingStint
            {
                AtBats = 200,
                CaughtStealing = 3,
                Doubles = 8,
                GroundedIntoDoublePlay = 10,
                Hits = 30,
                HomeRuns = 3,
                SacrificeFlies = 1,
                SacrificeHits = 1,
                StolenBases = 1,
                Strikeouts = 60,
                Triples = 1,
                Walks = 10
            };
        }
    }
}
