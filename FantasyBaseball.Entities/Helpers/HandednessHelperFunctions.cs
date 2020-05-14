using FantasyBaseball.Entities.Enums;

namespace FantasyBaseball.Entities.Helpers
{
    public static class HandednessHelperFunctions
    {
        public static Handedness StringToHandedness(string handedness)
        {
            switch (handedness?.Trim()?.ToUpper())
            {               
                case "L":
                case "Left":
                    return Handedness.Left;
                case "R":
                case "Right":
                    return Handedness.Right;
                case "S":
                case "Switch":
                case "B":
                case "Both":
                    return Handedness.Switch;
                default:
                    return Handedness.None;
            }
        }

        public static string HandednessToString(Handedness handedness)
        {
            switch (handedness)
            {
                case Handedness.Left:
                    return "L";
                case Handedness.Right:
                    return "R";
                case Handedness.Switch:
                    return "S";
                default:
                    return "None";
            }
        }

        public static Handedness DetermineBattingHandednessFromPitchingHandedness(Handedness battingHandedness, Handedness pitchingHandedness)
        {
            if (battingHandedness != Handedness.Switch && battingHandedness != Handedness.None)
            {
                return battingHandedness;
            }

            if (pitchingHandedness == Handedness.Left)
            {
                return Handedness.Right;
            }

            if (pitchingHandedness == Handedness.Right)
            {
                return Handedness.Left;
            }

            return Handedness.Right;
        }
    }
}