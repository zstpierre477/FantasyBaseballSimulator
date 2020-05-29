using FantasyBaseball.Entities.Models;
using FantasyBaseball.Repository;
using System.Collections.Generic;
using System.Linq;

namespace FantasyBaseball.Business.Services
{
    public class HistoricalTeamService : IHistoricalTeamService
    {
        ITeamRepository TeamRepository { get; set; }

        IBattingStintRepository BattingStintRepository { get; set; }

        IPitchingStintRepository PitchingStintRepository { get; set; }

        public HistoricalTeamService(ITeamRepository teamRepository, IBattingStintRepository battingStintRepository, IPitchingStintRepository pitchingStintRepository)
        {
            TeamRepository = teamRepository;
            BattingStintRepository = battingStintRepository;
            PitchingStintRepository = pitchingStintRepository;
        }

        public IEnumerable<Team> GetHistoricalTeams()
        {
            return TeamRepository.GetAllTeamNamesAndYears();
        }

        public Team GetHistoricalTeamWithPlayers(int teamId)
        {
            return TeamRepository.GetTeamWithPlayers(teamId);
        }

        public IEnumerable<Franchise> GetActiveHistoricalFranchises()
        {
            return TeamRepository.GetActiveFranchiseNames();
        }

        public Team GetHistoricalFranchiseAllTimePlayers(int franchiseId)
        {
            var playerStints = new List<PlayerStint>();
            var dhPool = new List<PlayerStint>();
            var catchers = BattingStintRepository.GetBestOPSBattingStintsByPositionFranchiseMinimumGamesPlayedAndMinimumAtBats(3, "C", franchiseId, 80, 350);
            playerStints.Add(catchers.First());
            dhPool.Add(catchers.Skip(1).First());
            var firstBasemen = BattingStintRepository.GetBestOPSBattingStintsByPositionFranchiseMinimumGamesPlayedAndMinimumAtBats(3, "1B", franchiseId, 80, 350);
            playerStints.Add(firstBasemen.First());
            dhPool.Add(firstBasemen.Skip(1).First());
            var secondBasemen = BattingStintRepository.GetBestOPSBattingStintsByPositionFranchiseMinimumGamesPlayedAndMinimumAtBats(3, "2B", franchiseId, 80, 350);
            playerStints.Add(secondBasemen.First());
            dhPool.Add(secondBasemen.Skip(1).First());
            var thirdBasemen = BattingStintRepository.GetBestOPSBattingStintsByPositionFranchiseMinimumGamesPlayedAndMinimumAtBats(3, "3B", franchiseId, 80, 350);
            playerStints.Add(thirdBasemen.First());
            dhPool.Add(thirdBasemen.Skip(1).First());
            var shortstops = BattingStintRepository.GetBestOPSBattingStintsByPositionFranchiseMinimumGamesPlayedAndMinimumAtBats(3, "SS", franchiseId, 80, 350);
            playerStints.Add(shortstops.First());
            dhPool.Add(shortstops.Skip(1).First());
            var middleInfielders = secondBasemen.Concat(shortstops);
            var cornerInfielders = firstBasemen.Concat(thirdBasemen);
            var noPositionOutFielders = BattingStintRepository.GetBestOPSBattingStintsByPositionFranchiseMinimumGamesPlayedAndMinimumAtBats(5, "OF", franchiseId, 80, 350).ToList();
            var outFielders = noPositionOutFielders.ToList();
            var leftFielders = BattingStintRepository.GetBestOPSBattingStintsByPositionFranchiseMinimumGamesPlayedAndMinimumAtBats(3, "LF", franchiseId, 80, 350);
            var startingOutFielders = leftFielders.Take(1).ToList();
            outFielders.AddRange(leftFielders);
            var centerFielders = BattingStintRepository.GetBestOPSBattingStintsByPositionFranchiseMinimumGamesPlayedAndMinimumAtBats(3, "CF", franchiseId, 80, 350);
            startingOutFielders.Add(centerFielders.First());
            outFielders.AddRange(centerFielders);
            var rightFielders = BattingStintRepository.GetBestOPSBattingStintsByPositionFranchiseMinimumGamesPlayedAndMinimumAtBats(3, "RF", franchiseId, 80, 350);
            startingOutFielders.Add(rightFielders.First());
            outFielders.AddRange(rightFielders);
            startingOutFielders = startingOutFielders.OrderBy(o => o.BattingStint.OnBasePlusSlugging).ToList();
            noPositionOutFielders = noPositionOutFielders.Where(n => startingOutFielders.Select(s => s.BattingStint.PersonId).Contains(n.BattingStint.PersonId) == false).ToList();

            if (noPositionOutFielders.Any())
            {
                var count = noPositionOutFielders.Count < 3 ? noPositionOutFielders.Count : 3;
                for (var i = 0; i < count; i++)
                {
                    if (noPositionOutFielders.First().BattingStint.OnBasePlusSlugging > startingOutFielders[i].BattingStint.OnBasePlusSlugging)
                    {
                        startingOutFielders[i] = noPositionOutFielders.First();
                        noPositionOutFielders.RemoveAt(0);
                    }
                }
            }

            playerStints.AddRange(startingOutFielders);
            dhPool.Add(outFielders.Where(o => startingOutFielders.Select(s => s.BattingStint.PersonId).Contains(o.BattingStint.PersonId) == false).First());
            dhPool.AddRange(BattingStintRepository.GetBestOPSBattingStintsByFranchiseAndMinimumAtBats(9, franchiseId, 350));

            playerStints.Add(dhPool.Where(d => playerStints.Select(p => p.BattingStint.PersonId).Contains(d.BattingStint.PersonId) == false).OrderByDescending(d => d.BattingStint.OnBasePlusSlugging).First());
            playerStints.Add(catchers.Where(c => playerStints.Select(p => p.BattingStint.PersonId).Contains(c.BattingStint.PersonId) == false).OrderByDescending(d => d.BattingStint.OnBasePlusSlugging).First());
            playerStints.Add(cornerInfielders.Where(c => playerStints.Select(p => p.BattingStint.PersonId).Contains(c.BattingStint.PersonId) == false).OrderByDescending(d => d.BattingStint.OnBasePlusSlugging).First());
            playerStints.Add(middleInfielders.Where(m => playerStints.Select(p => p.BattingStint.PersonId).Contains(m.BattingStint.PersonId) == false).OrderByDescending(d => d.BattingStint.OnBasePlusSlugging).First());
            playerStints.Add(outFielders.Where(o => playerStints.Select(p => p.BattingStint.PersonId).Contains(o.BattingStint.PersonId) == false).OrderByDescending(d => d.BattingStint.OnBasePlusSlugging).First());

            var startingPitchers = PitchingStintRepository.GetBestPitchingStintsByPositionFranchiseMinimumGamesPlayedAndMinimumAtBats(5, franchiseId, 10, 300);
            playerStints.AddRange(startingPitchers);
            var reliefPitchers = PitchingStintRepository.GetBestPitchingStintsByPositionFranchiseMinimumGamesPlayedAndMinimumAtBats(12, franchiseId, 0, 120);
            playerStints.AddRange(reliefPitchers.Where(r => startingPitchers.Select(s => s.PitchingStint.PersonId).Contains(r.PitchingStint.PersonId) == false).Take(7));

            return new Team { PlayerStints = playerStints };
        }
    }
}
