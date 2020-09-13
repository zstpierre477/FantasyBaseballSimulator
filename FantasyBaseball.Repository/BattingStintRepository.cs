using FantasyBaseball.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
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

        public PlayerStint GetRandomBattingStintByPositionYearMinimumGamesPlayedAndMinimumAtBats(string position, int year, int minimumGamesPlayed, int minimumAtBats)
        {
            using (var db = new FantasyBaseballDbContext())
            {
                var q1 = (from f in db.FieldingStint.AsNoTracking()
                          where f.Position == position && f.Year == year && f.Games >= minimumGamesPlayed
                          join b in db.BattingStint.AsNoTracking()
                          on new { f.PersonId, f.Stint, f.Year }
                          equals new { b.PersonId, b.Stint, b.Year }
                          where b.AtBats >= minimumAtBats
                          select b);

                var count = q1.Count();
                var index = new Random().Next(count);
                var battingStint = q1.Skip(index).FirstOrDefault();

                if (battingStint == null) return null;

                var q2 = (from b in db.BattingStint.AsNoTracking()
                          where b.BattingStintId == battingStint.BattingStintId
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

                return new PlayerStint
                {
                    BattingStint = q2.First().BattingStint,
                    Person = q2.First().Person,
                    Team = q2.First().Team,
                    FieldingStints = q2.Select(y => y.FieldingStint)
                };
            }
        }

        public IEnumerable<PlayerStint> GetBestOPSBattingStintsByPositionFranchiseMinimumGamesPlayedAndMinimumAtBats(int count, string position, int franchiseId, int minimumGamesPlayed, int minimumAtBats)
        {
            using (var db = new FantasyBaseballDbContext())
            {
                var q1 = (from f in db.FieldingStint.AsNoTracking()
                          where f.Position == position && f.Games >= minimumGamesPlayed
                          join t in db.Team.AsNoTracking()
                          on f.TeamId equals t.TeamId
                          join fr in db.Franchise.AsNoTracking()
                          on t.FranchiseId equals fr.FranchiseId
                          where fr.FranchiseId == franchiseId
                          join b in db.BattingStint.AsNoTracking()
                          on new { f.PersonId, f.Stint, f.Year }
                          equals new { b.PersonId, b.Stint, b.Year }
                          where b.AtBats >= minimumAtBats
                          orderby b.OnBasePlusSlugging descending
                          select b).Take(count*5).ToList();

                var batters = q1.GroupBy(q => q.PersonId).Select(g => g.First()).Take(count);

                var q2 = (from b in batters
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

                return q2.GroupBy(q => q.BattingStint.BattingStintId).Select(q => new PlayerStint
                {
                    BattingStint = q.First().BattingStint,
                    Person = q.First().Person,
                    Team = q.First().Team,
                    FieldingStints = q.Select(y => y.FieldingStint)
                });
            }
        }

        public IEnumerable<PlayerStint> GetBestOPSBattingStintsByFranchiseAndMinimumAtBats(int count, int franchiseId, int minimumAtBats)
        {
            using (var db = new FantasyBaseballDbContext())
            {
                var q1 = (from b in db.BattingStint.AsNoTracking()
                          where b.AtBats >= minimumAtBats
                          join t in db.Team.AsNoTracking()
                          on b.TeamId equals t.TeamId
                          join fr in db.Franchise.AsNoTracking()
                          on t.FranchiseId equals fr.FranchiseId
                          where fr.FranchiseId == franchiseId
                          orderby b.OnBasePlusSlugging descending
                          select b).Take(count*5).ToList();

                var batters = q1.GroupBy(q => q.PersonId).Select(g => g.First()).Take(count);

                var q2 = (from b in batters
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

                return q2.GroupBy(q => q.BattingStint.BattingStintId).Select(q => new PlayerStint
                {
                    BattingStint = q.First().BattingStint,
                    Person = q.First().Person,
                    Team = q.First().Team,
                    FieldingStints = q.Select(y => y.FieldingStint)
                });
            }
        }

        public PlayerStint GetRandomHallOfFameBattingStintByPositionMinimumGamesPlayedAndMinimumAtBats(string position, int minimumGamesPlayed, int minimumAtBats)
        {
            using (var db = new FantasyBaseballDbContext())
            {
                var q1 = (from h in db.HallOfFameMember.AsNoTracking()
                          where h.Inducted == true && h.Category == "Player"
                          join f in db.FieldingStint.AsNoTracking()
                          on h.PersonId equals f.PersonId
                          where f.Position == position && f.Games >= minimumGamesPlayed
                          join b in db.BattingStint.AsNoTracking()
                          on new { f.PersonId, f.Stint, f.Year }
                          equals new { b.PersonId, b.Stint, b.Year }
                          where b.AtBats >= minimumAtBats
                          select b);

                var count = q1.Count();
                var index = new Random().Next(count);
                var battingStint = q1.Skip(index).FirstOrDefault();

                if (battingStint == null) return null;

                var q2 = (from b in db.BattingStint.AsNoTracking()
                          where b.BattingStintId == battingStint.BattingStintId
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

                return new PlayerStint
                {
                    BattingStint = q2.First().BattingStint,
                    Person = q2.First().Person,
                    Team = q2.First().Team,
                    FieldingStints = q2.Select(y => y.FieldingStint)
                };
            }
        }

        public PlayerStint GetRandomAllStarBattingStintByPositionMinimumGamesPlayedAndMinimumAtBats(string position, int minimumGamesPlayed, int minimumAtBats)
        {
            using (var db = new FantasyBaseballDbContext())
            {
                var q1 = (from a in db.AllStar.AsNoTracking()
                          join f in db.FieldingStint.AsNoTracking()
                          on new { a.PersonId, a.Year, a.TeamId }
                          equals new { f.PersonId, f.Year, f.TeamId }
                          where f.Position == position && f.Games >= minimumGamesPlayed
                          join b in db.BattingStint.AsNoTracking()
                          on new { f.PersonId, f.Stint, f.Year }
                          equals new { b.PersonId, b.Stint, b.Year }
                          where b.AtBats >= minimumAtBats
                          select b);

                var count = q1.Count();
                var index = new Random().Next(count);
                var battingStint = q1.Skip(index).FirstOrDefault();

                if (battingStint == null) return null;

                var q2 = (from b in db.BattingStint.AsNoTracking()
                          where b.BattingStintId == battingStint.BattingStintId
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

                return new PlayerStint
                {
                    BattingStint = q2.First().BattingStint,
                    Person = q2.First().Person,
                    Team = q2.First().Team,
                    FieldingStints = q2.Select(y => y.FieldingStint)
                };
            }
        }
    }
}
