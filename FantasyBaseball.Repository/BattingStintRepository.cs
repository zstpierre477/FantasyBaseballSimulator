using FantasyBaseball.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FantasyBaseball.Repository
{
    public class BattingStintRepository
    {
        public IEnumerable<BattingStint> GetBattersByLastNameAndYear(string lastName, int year)
        {
            using(var db = new FantasyBaseballDbContext())
            {
                return db.BattingStints.Where(b => b.Year == year).Include(b => b.Person).Include(b => b.League).Include(b => b.Team);
            }
        }

    }
}
