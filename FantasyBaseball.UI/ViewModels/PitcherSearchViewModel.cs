using FantasyBaseball.Business.Services;
using FantasyBaseball.Entities.Enums;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Linq;

namespace FantasyBaseball.UI.ViewModels
{
    public class PitcherSearchViewModel : ViewModelBase
    {
        public IEnumerable<PitcherViewModel> Pitchers { get; set; }

        public string LastName { get; set; } 

        public int Year { get; set; }

        public IEnumerable<int> Years { get; set; }

        public IPlayerSearchService PlayerSearchService { get; set; }

        public PitcherSearchViewModel(IPlayerSearchServiceFactory playerSearchServiceFactory)
        {
            PlayerSearchService = playerSearchServiceFactory.GetPlayerSearchService(PlayerType.Pitcher);
            Years = Enumerable.Range(1871, 2019);
        }

        public void SearchPitcherByLastNameAndYear()
        {
            Pitchers = PlayerSearchService.SearchByLastNameAndYear(LastName, Year).Select(p => new PitcherViewModel(p));
        }
    }
}
