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
                return (from pi in db.PitchingStint.AsNoTracking()
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
                        on new { pi.PersonId, pi.Stint }
                        equals new { f.PersonId, f.Stint }
                        into fs
                        select (new PlayerStint
                        {
                            BattingStint = b,
                            FieldingStints = fs,
                            Person = pe,
                            PitchingStint = pi,
                            Team = t
                        })).ToList();
            }
        }
    }
}
