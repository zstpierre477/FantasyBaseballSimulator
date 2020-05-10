using FantasyBaseball.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FantasyBaseball.Repository
{
    public class PitchingStintRepository : IPitchingStintRepository
    {
        public IEnumerable<PlayerStint> GetPitchingStintByLastNameAndYear(string lastName, int year)
        {
            using(var db = new FantasyBaseballDbContext())
            {
                var q = (from pi in db.PitchingStint.AsNoTracking()
                        where pi.Year == year
                        join pe in db.Person.AsNoTracking()
                        on pi.PersonId equals pe.PersonId
                        where pe.LastName.Contains(lastName)
                        join t in db.Team.AsNoTracking()
                        on pi.TeamId equals t.TeamId
                        join b in db.BattingStint.AsNoTracking()
                        on new { pi.PersonId, pi.Stint }
                        equals new { b.PersonId, b.Stint }
                        join f in db.FieldingStint.AsNoTracking()
                        on new { pi.PersonId, pi.Stint, pi.Year }
                        equals new { f.PersonId, f.Stint, f.Year }
                        into fs
                        from f in fs.DefaultIfEmpty()
                        select (new
                        {
                            BattingStint = b,
                            FieldingStint = f,
                            Person = pe,
                            PitchingStint = pi,
                            Team = t
                        })).ToList();

                return q.GroupBy(x => x.PitchingStint.PitchingStintId).Select(x => new PlayerStint
                {
                    BattingStint = x.First().BattingStint,
                    Person = x.First().Person,
                    PitchingStint = x.First().PitchingStint,
                    Team = x.First().Team,
                    FieldingStints = x.Select(y => y.FieldingStint)
                }).ToList();
            }
        }

        public IEnumerable<PlayerStint> GetPitchingStintByYearMinimumGamesStartedAndMinimumInningsPitchedOuts(int year, int minimumGamesStarted, int minimumInningsPitchedOuts)
        {
            using (var db = new FantasyBaseballDbContext())
            {
                var q = (from pi in db.PitchingStint.AsNoTracking()
                        where pi.Year == year && pi.GamesStarted >= minimumGamesStarted && pi.InningsPitchedOuts >= minimumInningsPitchedOuts
                        join pe in db.Person.AsNoTracking()
                        on pi.PersonId equals pe.PersonId
                        join t in db.Team.AsNoTracking()
                        on pi.TeamId equals t.TeamId
                        join b in db.BattingStint.AsNoTracking()
                        on new { pi.PersonId, pi.Stint }
                        equals new { b.PersonId, b.Stint }
                        join f in db.FieldingStint.AsNoTracking()
                        on new { pi.PersonId, pi.Stint, pi.Year }
                        equals new { f.PersonId, f.Stint, f.Year }
                        into fs
                        from f in fs.DefaultIfEmpty()
                        select (new
                        {
                            BattingStint = b,
                            FieldingStint = f,
                            Person = pe,
                            PitchingStint = pi,
                            Team = t
                        })).ToList();

                return q.GroupBy(x => x.PitchingStint.PitchingStintId).Select(x => new PlayerStint
                {
                    BattingStint = x.First().BattingStint,
                    Person = x.First().Person,
                    PitchingStint = x.First().PitchingStint,
                    Team = x.First().Team,
                    FieldingStints = x.Select(y => y.FieldingStint)
                }).ToList();
            }
        }
    }
}
