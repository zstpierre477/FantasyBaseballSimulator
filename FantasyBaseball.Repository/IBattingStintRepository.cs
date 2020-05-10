using FantasyBaseball.Entities.Models;
using System.Collections.Generic;

namespace FantasyBaseball.Repository
{
    public interface IBattingStintRepository
    {
        IEnumerable<PlayerStint> GetBattingStintByLastNameAndYear(string lastName, int year);
        IEnumerable<PlayerStint> GetBattingStintByPositionYearAndMinimumGamesPlayed(string position, int year, int minimumGamesPlayed);
    }
}
