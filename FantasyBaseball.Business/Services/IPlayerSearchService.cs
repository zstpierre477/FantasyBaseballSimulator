using FantasyBaseball.Entities.Models;
using System.Collections.Generic;

namespace FantasyBaseball.Business.Services
{
    public interface IPlayerSearchService
    {
        IEnumerable<PlayerStint> SearchByLastNameAndYear(string lastName, int year);
    }
}
