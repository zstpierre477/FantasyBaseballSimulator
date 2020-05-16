using FantasyBaseball.Entities.Enums;
using FantasyBaseball.Entities.Models;

namespace FantasyBaseball.Business.Services
{
    public interface ISingleGameService
    {
        bool GetStealResult(BattingStint runner, FieldingStint catcher, BaseballBase baseballBase);
        BattingResult GetBattingResult(BattingStint batter, PitchingStint pitcher, bool isPitcherTired);
        FieldingResult GetFieldingResult(FieldingStint fielder, PositionType positionType, InfieldShiftType infieldShiftType, OutfieldShiftType outfieldShiftType);
        bool GetIsPassedBallResult(FieldingStint fielder);
        FieldingResult GetSacrificeBuntResult(BattingStint batter);
        FieldingResult GetBuntForAHitResult(BattingStint batter);
        bool GetHitAndRunResult(BattingStint batter);
    }
}
