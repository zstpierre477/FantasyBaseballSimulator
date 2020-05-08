using System;

namespace FantasyBaseball.Entities.Enums
{
    public enum PositionType
    {
        Pitcher,
        Catcher,
        FirstBaseman,
        SecondBaseman,
        ThirdBaseman,
        Shortstop,
        LeftFielder,
        CenterFielder,
        RightFielder,
        OutFielder,
        DesignatedHitter
    }

    public static class PositionTypeHelpers
    {
        public static PositionType ToPositionType(string position)
        {
            switch(position.Trim().ToUpper())
            {
                case "P":
                    return PositionType.Pitcher;
                case "C":
                    return PositionType.Catcher;
                case "1B":
                    return PositionType.FirstBaseman;
                case "2B":
                    return PositionType.SecondBaseman;
                case "3B":
                    return PositionType.ThirdBaseman;
                case "SS":
                    return PositionType.Shortstop;
                case "LF":
                    return PositionType.LeftFielder;
                case "CF":
                    return PositionType.CenterFielder;
                case "RF":
                    return PositionType.RightFielder;
                case "OF":
                    return PositionType.OutFielder;
                case "DH":
                    return PositionType.DesignatedHitter;
                default:
                    throw new ArgumentOutOfRangeException($"{position} is not a valid position.");
            }
        }
    } 
}
