using FantasyBaseball.Entities.Models;
using System.Collections.Generic;

namespace FantasyBaseball.Repository
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetAllTeamNamesAndYears();
        Team GetTeamWithPlayers(int teamId);
    }
}
