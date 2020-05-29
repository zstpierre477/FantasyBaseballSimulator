using FantasyBaseball.Entities.Models;
using System.Collections.Generic;

namespace FantasyBaseball.Repository
{
    public interface IBattingStintRepository
    {
        IEnumerable<PlayerStint> GetBattingStintByLastNameAndYear(string lastName, int year);
        PlayerStint GetRandomBattingStintByPositionYearMinimumGamesPlayedAndMinimumAtBats(string position, int year, int minimumGamesPlayed, int minimumAtBats);
        PlayerStint GetRandomHallOfFameBattingStintByPositionMinimumGamesPlayedAndMinimumAtBats(string position, int minimumGamesPlayed, int minimumAtBats);
        PlayerStint GetRandomAllStarBattingStintByPositionMinimumGamesPlayedAndMinimumAtBats(string position, int minimumGamesPlayed, int minimumAtBats);
        IEnumerable<PlayerStint> GetBestOPSBattingStintsByPositionFranchiseMinimumGamesPlayedAndMinimumAtBats(int count, string position, int franchiseId, int minimumGamesPlayed, int minimumAtBats);
        IEnumerable<PlayerStint> GetBestOPSBattingStintsByFranchiseAndMinimumAtBats(int count, int franchiseId, int minimumAtBats);
    }
}
