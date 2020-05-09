using FantasyBaseball.Business.Services;
using FantasyBaseball.Entities.Enums;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Linq;

namespace FantasyBaseball.UI.ViewModels
{
    public class BatterSearchViewModel : ViewModelBase
    {
        public IEnumerable<BatterViewModel> Batters { get; set; }

        public string LastName { get; set; } 

        public int Year { get; set; }

        public IEnumerable<int> Years { get; set; }

        public IPlayerSearchService PlayerSearchService { get; set; }

        public BatterSearchViewModel(IPlayerSearchServiceFactory playerSearchServiceFactory)
        {
            PlayerSearchService = playerSearchServiceFactory.GetPlayerSearchService(PlayerType.Batter);
            Years = Enumerable.Range(1871, 2019);
        }

        public void SearchBatterByLastNameAndYear()
        {
            Batters = PlayerSearchService.SearchByLastNameAndYear(LastName, Year).Select(p => new BatterViewModel(p));
        }
    }
}
