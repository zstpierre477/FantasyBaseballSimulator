using FantasyBaseball.Entities.Enums;
using System;

namespace FantasyBaseball.Entities.Helpers
{
    public static class PositionTypeHelperFunctions
    {
        public static PositionType PositionAbbreviationStringToPositionType(string position)
        {
            switch (position.Trim().ToUpper())
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

        public static PositionType NumberToPositionType(int position)
        {
            switch (position)
            {
                case 1:
                    return PositionType.Pitcher;
                case 2:
                    return PositionType.Catcher;
                case 3:
                    return PositionType.FirstBaseman;
                case 4:
                    return PositionType.SecondBaseman;
                case 5:
                    return PositionType.ThirdBaseman;
                case 6:
                    return PositionType.Shortstop;
                case 7:
                    return PositionType.LeftFielder;
                case 8:
                    return PositionType.CenterFielder;
                case 9:
                    return PositionType.RightFielder;
                default:
                    throw new ArgumentOutOfRangeException($"{position} is not a valid position number.");
            }
        }

        public static string PositionTypeToPositionAbbreviationString(PositionType positionType)
        {
            switch (positionType)
            {
                case PositionType.Pitcher:
                    return "P";
                case PositionType.Catcher:
                    return "C";
                case PositionType.FirstBaseman:
                    return "1B";
                case PositionType.SecondBaseman:
                    return "2B";
                case PositionType.ThirdBaseman:
                    return "3B";
                case PositionType.Shortstop:
                    return "SS";
                case PositionType.LeftFielder:
                    return "LF";
                case PositionType.CenterFielder:
                    return "CF";
                    case PositionType.RightFielder:
                    return "RF";
                case PositionType.OutFielder:
                    return "OF";
                case PositionType.DesignatedHitter:
                    return "DH";
                default:
                    throw new ArgumentOutOfRangeException($"{positionType} is not a valid position type.");
            }
        }

        public static string NumberToPositionAbbreviationString(int position)
        {
            switch (position)
            {
                case 1:
                    return "P";
                case 2:
                    return "C";
                case 3:
                    return "1B";
                case 4:
                    return "2B";
                case 5:
                    return "3B";
                case 6:
                    return "SS";
                case 7:
                    return "LF";
                case 8:
                    return "CF";
                case 9:
                    return "RF";
                default:
                    throw new ArgumentOutOfRangeException($"{position} is not a valid position number.");
            }
        }
    }
}
