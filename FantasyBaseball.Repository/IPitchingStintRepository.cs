using FantasyBaseball.Entities.Models;
using System.Collections.Generic;

namespace FantasyBaseball.Repository
{
    public interface IPitchingStintRepository
    {
        IEnumerable<PlayerStint> GetPitchingStintByLastNameAndYear(string lastName, int year);
    }
}
