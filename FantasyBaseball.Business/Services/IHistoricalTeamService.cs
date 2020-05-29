using FantasyBaseball.Entities.Models;
using System.Collections.Generic;

namespace FantasyBaseball.Business.Services
{
    public interface IHistoricalTeamService
    {
        IEnumerable<Team> GetHistoricalTeams();
        Team GetHistoricalTeamWithPlayers(int teamId);
        IEnumerable<Franchise> GetActiveHistoricalFranchises();
        Team GetHistoricalFranchiseAllTimePlayers(int franchiseId);
    }
}
