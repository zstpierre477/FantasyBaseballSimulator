using FantasyBaseball.Entities.Enums;
using FantasyBaseball.Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace FantasyBaseball.Entities.Helpers
{
    public static class FieldingStintHelperFunctions
    {
        public static FieldingStint CreateFieldingStintForPlayerOutOfPosition(PositionType positionType)
        {
            return new FieldingStint
            {
                Assists = 1,
                CaughtStealing = 1,
                DoublePlays = 0,
                Errors = 3,
                Games = 1,
                GamesStarted = 0,
                InningsPlayedOuts = 3,
                PassedBalls = 1,
                PositionType = positionType,
                Putouts = 1,
                StolenBases = 3
            };
        }

        public static IEnumerable<FieldingStint> CombineSamePersonTeamAndYearFieldingStints(this IEnumerable<FieldingStint> fieldingStints)
        {
            if (fieldingStints.Any() == false)
            {
                return null;
            }

            return fieldingStints.GroupBy(p => p.Position).Select(f => new FieldingStint
            {
                Assists = (short)f.Sum(p => p.Assists),
                CaughtStealing = (short)f.Sum(p => p.CaughtStealing),
                DoublePlays = (short)f.Sum(p => p.DoublePlays),
                Errors = (short)f.Sum(p => p.Errors),
                Games = (short)f.Sum(p => p.Games),
                GamesStarted = (short)f.Sum(p => p.GamesStarted),
                InningsPlayedOuts = (short)f.Sum(p => p.InningsPlayedOuts),
                LeagueId = f.First().LeagueId,
                PassedBalls = (short)f.Sum(p => p.PassedBalls),
                PersonId = f.First().PersonId,
                Position = f.First().Position,
                PositionType = PositionTypeHelperFunctions.PositionAbbreviationStringToPositionType(f.First().Position),
                Putouts = (short)f.Sum(p => p.Putouts),
                StolenBases = (short)f.Sum(p => p.StolenBases),
                TeamAbbreviation = f.First().TeamAbbreviation,
                TeamId = f.First().TeamId,
                WildPitches = (short)f.Sum(p => p.WildPitches),
                Year = f.First().Year
            });
        }
    }
}
