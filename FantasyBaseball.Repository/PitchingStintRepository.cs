using FantasyBaseball.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
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
                    FieldingStints = x.GroupBy(q => q.FieldingStint.FieldingStintId).Select(y => y.First().FieldingStint)
                }).ToList();
            }
        }

        public PlayerStint GetRandomPitchingStintByYearMinimumGamesStartedAndMinimumInningsPitchedOuts(int year, int minimumGamesStarted, int minimumInningsPitchedOuts)
        {
            using (var db = new FantasyBaseballDbContext())
            {
                var q1 = (from pi in db.PitchingStint.AsNoTracking()
                          where pi.Year == year && pi.GamesStarted >= minimumGamesStarted && pi.InningsPitchedOuts >= minimumInningsPitchedOuts
                          select pi);

                var count = q1.Count();
                var index = new Random().Next(count);
                var pitchingStint = q1.Skip(index).FirstOrDefault();

                if (pitchingStint == null) return null;

                var q2 = (from pi in db.PitchingStint.AsNoTracking()
                          where pi.PitchingStintId == pitchingStint.PitchingStintId
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

                return new PlayerStint
                {
                    BattingStint = q2.First().BattingStint,
                    Person = q2.First().Person,
                    PitchingStint = q2.First().PitchingStint,
                    Team = q2.First().Team,
                    FieldingStints = q2.GroupBy(q => q.FieldingStint.FieldingStintId).Select(y => y.First().FieldingStint)
                };
            }
        }

        public IEnumerable<PlayerStint> GetBestPitchingStintsByPositionFranchiseMinimumGamesPlayedAndMinimumAtBats(int count, int franchiseId, int minimumGamesStarted, int minimumInningsPitchedOuts)
        {
            using (var db = new FantasyBaseballDbContext())
            {
                var q1 = (from pi in db.PitchingStint.AsNoTracking()
                          where pi.GamesStarted >= minimumGamesStarted && pi.InningsPitchedOuts >= minimumInningsPitchedOuts
                          join t in db.Team.AsNoTracking()
                          on pi.TeamId equals t.TeamId
                          join fr in db.Franchise.AsNoTracking()
                          on t.FranchiseId equals fr.FranchiseId
                          where fr.FranchiseId == franchiseId
                          orderby pi.WalksAndHitsPerInningsPitchedPlusEarnedRunAverage
                          select pi).Take(count*3).ToList();

                var pitchers = q1.GroupBy(q => q.PersonId).Select(g => g.First()).Take(count);

                var q2 = (from pi in pitchers
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

                return q2.GroupBy(q => q.PitchingStint.PitchingStintId).Select(q => new PlayerStint
                {
                    BattingStint = q.First().BattingStint,
                    Person = q.First().Person,
                    PitchingStint = q.First().PitchingStint,
                    Team = q.First().Team,
                    FieldingStints = q2.GroupBy(q => q.FieldingStint.FieldingStintId).Select(y => y.First().FieldingStint)
                });
            }
        }

        public PlayerStint GetRandomHallOfFamePitchingStintByMinimumGamesStartedAndMinimumInningsPitchedOuts(int minimumGamesStarted, int minimumInningsPitchedOuts)
        {
            using (var db = new FantasyBaseballDbContext())
            {
                var q1 = (from h in db.HallOfFameMember.AsNoTracking()
                          join pi in db.PitchingStint.AsNoTracking()
                          on h.PersonId equals pi.PersonId
                          where pi.GamesStarted >= minimumGamesStarted && pi.InningsPitchedOuts >= minimumInningsPitchedOuts
                          select pi);

                var count = q1.Count();
                var index = new Random().Next(count);
                var pitchingStint = q1.Skip(index).FirstOrDefault();

                if (pitchingStint == null) return null;

                var q2 = (from pi in db.PitchingStint.AsNoTracking()
                          where pi.PitchingStintId == pitchingStint.PitchingStintId
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

                return new PlayerStint
                {
                    BattingStint = q2.First().BattingStint,
                    Person = q2.First().Person,
                    PitchingStint = q2.First().PitchingStint,
                    Team = q2.First().Team,
                    FieldingStints = q2.GroupBy(q => q.FieldingStint.FieldingStintId).Select(y => y.First().FieldingStint)
                };
            }
        }

        public PlayerStint GetRandomAllStarPitchingStintByMinimumGamesStartedAndMinimumInningsPitchedOuts(int minimumGamesStarted, int minimumInningsPitchedOuts)
        {
            using (var db = new FantasyBaseballDbContext())
            {
                var q1 = (from a in db.AllStar.AsNoTracking()
                          join pi in db.PitchingStint.AsNoTracking()
                          on new { a.PersonId, a.Year, a.TeamId }
                          equals new { pi.PersonId, pi.Year, pi.TeamId }
                          where pi.GamesStarted >= minimumGamesStarted && pi.InningsPitchedOuts >= minimumInningsPitchedOuts
                          select pi);

                var count = q1.Count();
                var index = new Random().Next(count);
                var pitchingStint = q1.Skip(index).FirstOrDefault();

                if (pitchingStint == null) return null;

                var q2 = (from pi in db.PitchingStint.AsNoTracking()
                          where pi.PitchingStintId == pitchingStint.PitchingStintId
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

                return new PlayerStint
                {
                    BattingStint = q2.First().BattingStint,
                    Person = q2.First().Person,
                    PitchingStint = q2.First().PitchingStint,
                    Team = q2.First().Team,
                    FieldingStints = q2.GroupBy(q => q.FieldingStint.FieldingStintId).Select(y => y.First().FieldingStint)
                };
            }
        }
    }
}
