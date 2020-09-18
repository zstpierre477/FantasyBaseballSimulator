using FantasyBaseball.Entities.Models;
using System.Collections.Generic;
using System.Linq;

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

        public static PitchingStint CombineSamePersonTeamAndYearPitchingStints(this IEnumerable<PitchingStint> pitchingStints)
        {
            pitchingStints = pitchingStints.ToList();

            if (pitchingStints.Any() == false)
            {
                return null;
            }

            return new PitchingStint
            {
                Balks = (short)pitchingStints.Sum(p => p.Balks),
                BattersFaced = (short)pitchingStints.Sum(p => p.BattersFaced),
                CompleteGames = (short)pitchingStints.Sum(p => p.CompleteGames),
                EarnedRuns = (short)pitchingStints.Sum(p => p.EarnedRuns),
                Games = (short)pitchingStints.Sum(p => p.Games),
                GamesFinished = (short)pitchingStints.Sum(p => p.GamesFinished),
                GamesStarted = (short)pitchingStints.Sum(p => p.GamesStarted),
                HitBatters = (short)pitchingStints.Sum(p => p.HitBatters),
                Hits = (short)pitchingStints.Sum(p => p.Hits),
                HomeRuns = (short)pitchingStints.Sum(p => p.HomeRuns),
                InducedDoublePlays = (short)pitchingStints.Sum(p => p.InducedDoublePlays),
                InningsPitchedOuts = (short)pitchingStints.Sum(p => p.InningsPitchedOuts),
                IntentionalWalks = (short)pitchingStints.Sum(p => p.IntentionalWalks),
                LeagueId = pitchingStints.First().LeagueId,
                Losses = (short)pitchingStints.Sum(p => p.Losses),
                PersonId = pitchingStints.First().PersonId,
                Runs = (short)pitchingStints.Sum(p => p.Runs),
                SacrificeFlies = (short)pitchingStints.Sum(p => p.SacrificeFlies),
                SacrificeHits = (short)pitchingStints.Sum(p => p.SacrificeHits),
                Saves = (short)pitchingStints.Sum(p => p.Saves),
                Shutouts = (short)pitchingStints.Sum(p => p.Shutouts),
                Strikeouts = (short)pitchingStints.Sum(p => p.Strikeouts),
                TeamAbbreviation = pitchingStints.First().TeamAbbreviation,
                TeamId = pitchingStints.First().TeamId,
                Walks = (short)pitchingStints.Sum(p => p.Walks),
                WildPitches = (short)pitchingStints.Sum(p => p.WildPitches),
                Wins = (short)pitchingStints.Sum(p => p.Wins),
                Year = pitchingStints.First().Year,
                WalksAndHitsPerInningsPitched = pitchingStints.Sum(p => p.InningsPitchedOuts) == 0 ? .000 : pitchingStints.Sum(p => p.Walks + p.Hits)/(((float)pitchingStints.Sum(p => p.InningsPitchedOuts))/3),
                WalksAndHitsPerInningsPitchedPlusEarnedRunAverage = pitchingStints.Sum(p => p.InningsPitchedOuts) == 0 ? .000 : pitchingStints.Sum(p => p.Walks + p.Hits) / (((float)pitchingStints.Sum(p => p.InningsPitchedOuts)) / 3) + (9*(pitchingStints.Sum(p => p.EarnedRuns)/(((float)pitchingStints.Sum(p => p.InningsPitchedOuts))/3)))
            };
        }
    }
}
