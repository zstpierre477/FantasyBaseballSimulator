using FantasyBaseball.Business.Services;
using FantasyBaseball.Entities.Enums;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FantasyBaseball.UI.ViewModels
{
    public class BatterSearchViewModel : ViewModelBase
    {
        private ObservableCollection<BatterViewModel> _batters { get; set; }
        public ObservableCollection<BatterViewModel> Batters
        {
            get { return _batters; }
            set { _batters = value; RaisePropertyChanged("Batters"); }
        }

        public string LastName { get; set; } 

        public int Year { get; set; }

        public ObservableCollection<int> Years { get; set; }

        public IPlayerSearchService PlayerSearchService { get; set; }

        public BatterSearchViewModel(IPlayerSearchServiceFactory playerSearchServiceFactory)
        {
            PlayerSearchService = playerSearchServiceFactory.GetPlayerSearchService(PlayerType.Batter);
            Years = new ObservableCollection<int>(Enumerable.Range(1871, 149));
            Year = 2019;
        }

        public void SearchBatterByLastNameAndYear()
        {
            Batters = new ObservableCollection<BatterViewModel>(PlayerSearchService.SearchByLastNameAndYear(LastName, Year).Select(p => new BatterViewModel(p)));
        }
    }
}
