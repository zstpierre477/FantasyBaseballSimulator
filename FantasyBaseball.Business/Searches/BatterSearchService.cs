using FantasyBaseball.Repository;
using FantasyBaseball.UI.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace FantasyBaseball.Business.Searches
{
    public class BatterSearchService
    {
        public BattingStintRepository BattingStintRepository { get; set; }

        public IEnumerable<BatterModel> SearchBatterByLastNameAndYear(string lastName, int year)
        {
            var batters = BattingStintRepository.GetBattersByLastNameAndYear(lastName, year);
            return batters.Select(b => new BatterModel
            {
                AtBats = b.AtBats,
                BattingStintId = b.BattingStintId,
                CaughtStealing = b.CaughtStealing,
                FirstName = b.Person.NameFirst,
                Games = b.Games,
                Hits = b.Hits,
                HomeRuns = b.HomeRuns,
                LastName = b.Person.NameLast,
                Runs = b.Runs,
                RunsBattedIn = b.RunsBattedIn,
                StolenBases = b.StolenBases,
                TeamName = b.Team.Name,
                TeamShortName = b.Team.TeamIdBR,
                Walks = b.Walks,
                Year = b.Year
            });
        }
    }
}
