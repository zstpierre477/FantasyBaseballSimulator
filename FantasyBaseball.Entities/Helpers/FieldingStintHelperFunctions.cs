using FantasyBaseball.Entities.Enums;
using FantasyBaseball.Entities.Models;

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
    }
}
