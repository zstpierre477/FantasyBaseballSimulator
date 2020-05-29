using FantasyBaseball.Entities.Models;
using System.Collections.Generic;

namespace FantasyBaseball.Repository
{
    public interface IPitchingStintRepository
    {
        IEnumerable<PlayerStint> GetPitchingStintByLastNameAndYear(string lastName, int year);
        PlayerStint GetRandomPitchingStintByYearMinimumGamesStartedAndMinimumInningsPitchedOuts(int year, int minimumGamesStarted, int minimumInningsPitchedOuts);
        PlayerStint GetRandomHallOfFamePitchingStintByMinimumGamesStartedAndMinimumInningsPitchedOuts(int minimumGamesStarted, int minimumInningsPitchedOuts);
        PlayerStint GetRandomAllStarPitchingStintByMinimumGamesStartedAndMinimumInningsPitchedOuts(int minimumGamesStarted, int minimumInningsPitchedOuts);
        IEnumerable<PlayerStint> GetBestPitchingStintsByPositionFranchiseMinimumGamesPlayedAndMinimumAtBats(int count, int franchiseId, int minimumGamesStarted, int minimumInningsPitchedOuts);
    }
}
