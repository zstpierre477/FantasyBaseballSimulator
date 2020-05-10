using FantasyBaseball.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;

namespace FantasyBaseball.Repository
{
    public class BattingStintRepository : IBattingStintRepository
    {
        public IEnumerable<PlayerStint> GetBattingStintByLastNameAndYear(string lastName, int year)
        {
            using(var db = new FantasyBaseballDbContext())
            {
                var q = (from b in db.BattingStint.AsNoTracking()
                        where b.Year == year
                        join p in db.Person.AsNoTracking()
                        on b.PersonId equals p.PersonId
                        where p.LastName.Contains(lastName)
                        join t in db.Team.AsNoTracking()
                        on b.TeamId equals t.TeamId
                        join f in db.FieldingStint.AsNoTracking()
                        on new { b.PersonId, b.Stint, b.Year }
                        equals new { f.PersonId, f.Stint, f.Year } 
                        into fs
                        from f in fs.DefaultIfEmpty()
                        select (new
                        {
                            BattingStint = b,
                            FieldingStint = f,
                            Person = p,
                            Team = t
                        })).ToList();

                return q.GroupBy(x => x.BattingStint.BattingStintId).Select(x => new PlayerStint
                {
                    BattingStint = x.First().BattingStint,
                    Person = x.First().Person,
                    Team = x.First().Team,
                    FieldingStints = x.Select(y => y.FieldingStint)
                }).ToList();
            }
        }

        public IEnumerable<PlayerStint> GetBattingStintByPositionYearAndMinimumGamesPlayed(string position, int year, int minimumGamesPlayed)
        {
            using (var db = new FantasyBaseballDbContext())
            {
                var q = (from f in db.FieldingStint.AsNoTracking()
                         where f.Position == position && f.Year == year && f.Games >= minimumGamesPlayed
                         join b in db.BattingStint.AsNoTracking()
                         on new { f.PersonId, f.Stint, f.Year }
                         equals new { b.PersonId, b.Stint, b.Year }
                         join p in db.Person.AsNoTracking()
                         on b.PersonId equals p.PersonId
                         join t in db.Team.AsNoTracking()
                         on b.TeamId equals t.TeamId
                         join fi in db.FieldingStint.AsNoTracking()
                         on new { b.PersonId, b.Stint, b.Year }
                         equals new { fi.PersonId, fi.Stint, fi.Year }
                         into fs
                         from fi in fs.DefaultIfEmpty()
                         select (new
                         {
                             BattingStint = b,
                             FieldingStint = fi,
                             Person = p,
                             Team = t
                         })).ToList();

                return q.GroupBy(x => x.BattingStint.BattingStintId).Select(x => new PlayerStint
                {
                    BattingStint = x.First().BattingStint,
                    Person = x.First().Person,
                    Team = x.First().Team,
                    FieldingStints = x.Select(y => y.FieldingStint)
                }).ToList();
            }
        }
    }
}
