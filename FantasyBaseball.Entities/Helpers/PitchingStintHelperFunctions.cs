using FantasyBaseball.Entities.Models;

namespace FantasyBaseball.Entities.Helpers
{
    public static class PitchingStintHelperFunctions
    {
        public static PitchingStint CreatePitchingStintForNonPitcher()
        {
            return new PitchingStint
            {
                Balks = 1,
                BattersFaced = 18,
                HitBatters = 1,
                Hits = 5,
                HomeRuns = 1,
                InducedDoublePlays = 1,
                InningsPitchedOuts = 6,
                Strikeouts = 1,
                Walks = 5,
                WildPitches = 1
            };
        }
    }
}
