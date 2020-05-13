using FantasyBaseball.Entities.Helpers;
using FantasyBaseball.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FantasyBaseball.Repository
{
    public class TeamRepository : ITeamRepository
    {
        public IEnumerable<Team> GetAllTeamNamesAndYears()
        {
            using (var db = new FantasyBaseballDbContext())
            {
                return (from t in db.Team.AsNoTracking()
                        select new Team
                        {
                            Name = t.Name,
                            TeamId = t.TeamId,
                            Year = t.Year
                        }).ToList();
            }

        }

            public Team GetTeamWithPlayers(int teamId)
        {
            using (var db = new FantasyBaseballDbContext())
            {
                var q = (from t in db.Team.AsNoTracking()
                         where t.TeamId == teamId
                         join pi in db.PitchingStint.AsNoTracking()
                         on t.TeamId equals pi.TeamId 
                         into pis
                         from pi in pis.DefaultIfEmpty()
                         join b in db.BattingStint.AsNoTracking()
                         on t.TeamId equals b.TeamId
                         into bs
                         from b in bs.DefaultIfEmpty()
                         join f in db.FieldingStint.AsNoTracking()
                         on t.TeamId equals f.TeamId
                         into fs
                         from f in fs.DefaultIfEmpty()
                         join pe in db.Person.AsNoTracking()
                         on f.PersonId equals pe.PersonId
                         into pes
                         from pe in pes.DefaultIfEmpty()

                         select (new
                         {
                             BattingStint = b,
                             FieldingStint = f,
                             Person = pe,
                             PitchingStint = pi,
                             Team = t
                         })).ToList();

                var team = new Team
                {
                    Name = q.First().Team.Name,
                    Year = q.First().Team.Year,
                    BattingStint = q.GroupBy(s => s.BattingStint.BattingStintId).Select(s => s.First().BattingStint).ToList(),
                    PitchingStint = q.GroupBy(s => s.PitchingStint.PitchingStintId).Select(s => s.First().PitchingStint).ToList(),
                    FieldingStint = q.GroupBy(s => s.FieldingStint.FieldingStintId).Select(s => s.First().FieldingStint).ToList(),
                };

                team.PlayerStints = q.GroupBy(p => p.Person.PersonId).Select(p => p.First()).Select(p => new PlayerStint
                {
                    BattingStint = team.BattingStint.Where(s => s.PersonId == p.Person.PersonId).CombineSamePersonTeamAndYearBattingStints(),
                    Person = p.Person,
                    PitchingStint = team.PitchingStint.Where(s => s.PersonId == p.Person.PersonId).CombineSamePersonTeamAndYearPitchingStints(),
                    FieldingStints = team.FieldingStint.Where(s => s.PersonId == p.Person.PersonId).CombineSamePersonTeamAndYearFieldingStints().ToList(),
                    Team = team
                }).ToList();

                return team;
            }
        }
    }
}
