using FantasyBaseball.Entities.Models;
using System.Collections.Generic;

namespace FantasyBaseball.Repository
{
    public interface IPitchingStintRepository
    {
        IEnumerable<PlayerStint> GetPitchingStintByLastNameAndYear(string lastName, int year);
        IEnumerable<PlayerStint> GetPitchingStintByYearMinimumGamesStartedAndMinimumInningsPitchedOuts(int year, int minimumGamesStarted, int minimumInningsPitchedOuts);
    }
}
