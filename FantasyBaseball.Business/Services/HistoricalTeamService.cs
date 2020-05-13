using FantasyBaseball.Entities.Models;
using FantasyBaseball.Repository;
using System.Collections.Generic;

namespace FantasyBaseball.Business.Services
{
    public class HistoricalTeamService : IHistoricalTeamService
    {
        ITeamRepository TeamRepository { get; set; }

        public HistoricalTeamService(ITeamRepository teamRepository)
        {
            TeamRepository = teamRepository;
        }

        public IEnumerable<Team> GetHistoricalTeams()
        {
            return TeamRepository.GetAllTeamNamesAndYears();
        }

        public Team GetHistoricalTeamWithPlayers(int teamId)
        {
            return TeamRepository.GetTeamWithPlayers(teamId);
        }
    }
}
