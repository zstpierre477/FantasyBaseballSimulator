using FantasyBaseball.Entities.Enums;

namespace FantasyBaseball.Entities.Helpers
{
    public static class DefensiveShiftHelperFunctions
    {
        public static InfieldShiftType InfieldShiftStringToType(string shift)
        {
            switch (shift?.Trim()?.ToUpper())
            {
                case "Infield In":
                    return InfieldShiftType.InfieldIn;
                default:
                    return InfieldShiftType.None;
            }
        }

        public static string InfieldShiftTypeToString(InfieldShiftType shift)
        {
            switch (shift)
            {
                case InfieldShiftType.InfieldIn:
                    return "Infield In";
                default:
                    return "None";
            }
        }

        public static OutfieldShiftType OutfieldShiftStringToType(string shift)
        {
            switch (shift?.Trim()?.ToUpper())
            {
                case "Outfield In":
                    return OutfieldShiftType.OutfieldIn;
                default:
                    return OutfieldShiftType.None;
            }
        }

        public static string OutfieldShiftTypeToString(OutfieldShiftType shift)
        {
            switch (shift)
            {
                case OutfieldShiftType.OutfieldIn:
                    return "Outfield In";
                default:
                    return "None";
            }
        }
    }
}
