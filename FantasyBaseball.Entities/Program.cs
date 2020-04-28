using System;
using System.Linq;

namespace FantasyBaseball.Entities
{
    class Program
    {
        static void Main()
        {
            using (var db = new FantasyBaseballDbContext())
            {
                // Create
                Console.WriteLine("Inserting a new league");
                db.Add(new Person { FirstName = "test", LastName = "person" });
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying for a league");
                var league = db.Leagues
                    .OrderBy(b => b.LeagueId)
                    .First();

                // Update
                Console.WriteLine("Updating the league");
                league.LeagueName = "National League";
                db.SaveChanges();

                // Delete
                Console.WriteLine("Delete the league");
                db.Remove(league);
                db.SaveChanges();
            }
        }
    }
}