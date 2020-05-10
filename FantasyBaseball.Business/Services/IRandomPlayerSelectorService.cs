using FantasyBaseball.Entities.Enums;
using FantasyBaseball.Entities.Models;

namespace FantasyBaseball.Business.Services
{
    public interface IRandomPlayerSelectorService
    {
        PlayerStint SelectRandomBatter(PositionType positionType, bool starter = false);
        PlayerStint SelectRandomPitcher(bool starter = false);
    }
}
