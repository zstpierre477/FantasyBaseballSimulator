using FantasyBaseball.Entities.Models;
using Microsoft.EntityFrameworkCore;
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
                return (from b in db.BattingStint.AsNoTracking()
                        where b.Year == year
                        join p in db.Person.AsNoTracking()
                        on b.PersonId equals p.PersonId
                        where p.LastName.Contains(lastName)
                        join t in db.Team.AsNoTracking()
                        on b.TeamId equals t.TeamId
                        join f in db.FieldingStint.AsNoTracking()
                        on new { b.PersonId, b.Stint }
                        equals new { f.PersonId, f.Stint } 
                        into fs
                        select (new PlayerStint
                        {
                            BattingStint = b,
                            FieldingStints = fs,
                            Person = p,
                            Team = t
                        })).ToList();
            }
        }
    }
}
