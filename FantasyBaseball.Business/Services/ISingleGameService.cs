using FantasyBaseball.Entities.Enums;
using FantasyBaseball.Entities.Models;

namespace FantasyBaseball.Business.Services
{
    public interface ISingleGameService
    {
        bool GetStealResult(BattingStint runner, FieldingStint catcher);
        BattingResult GetBattingResult(BattingStint batter, PitchingStint pitcher);
        public FieldingResult GetFieldingResult(FieldingStint fielder);
        public bool GetIsPassedBallResult(FieldingStint fielder);
    }
}
