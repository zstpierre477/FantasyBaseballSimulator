using FantasyBaseball.Entities.Models;
using System.Collections.Generic;
using System.Linq;

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

        public static BattingStint CombineSamePersonTeamAndYearBattingStints(this IEnumerable<BattingStint> battingStints)
        {
            if (battingStints.Any() == false)
            {
                return null;
            }

            return new BattingStint
            {
                AtBats = (short)battingStints.Sum(b => b.AtBats),
                CaughtStealing = (short)battingStints.Sum(b => b.CaughtStealing),
                Doubles = (short)battingStints.Sum(b => b.Doubles),
                Games = (short)battingStints.Sum(b => b.Games),
                GamesBatted = (short)battingStints.Sum(b => b.GamesBatted),
                GroundedIntoDoublePlay = (short)battingStints.Sum(b => b.GroundedIntoDoublePlay),
                HitByPitch = (short)battingStints.Sum(b => b.HitByPitch),
                Hits = (short)battingStints.Sum(b => b.Hits),
                HomeRuns = (short)battingStints.Sum(b => b.HomeRuns),
                IntentionalWalks = (short)battingStints.Sum(b => b.IntentionalWalks),
                LeagueId = battingStints.First().LeagueId,
                PersonId = battingStints.First().PersonId,
                Runs = (short)battingStints.Sum(b => b.Runs),
                RunsBattedIn = (short)battingStints.Sum(b => b.RunsBattedIn),
                SacrificeFlies = (short)battingStints.Sum(b => b.SacrificeFlies),
                SacrificeHits = (short)battingStints.Sum(b => b.SacrificeHits),
                StolenBases = (short)battingStints.Sum(b => b.StolenBases),
                Strikeouts = (short)battingStints.Sum(b => b.Strikeouts),
                TeamAbbreviation = battingStints.First().TeamAbbreviation,
                TeamId = battingStints.First().TeamId,
                Triples = (short)battingStints.Sum(b => b.Triples),
                Walks = (short)battingStints.Sum(b => b.Walks),
                Year = battingStints.First().Year
            };
        }
    }
}
