using FantasyBaseball.Business.Services;
using FantasyBaseball.Entities.Enums;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FantasyBaseball.UI.ViewModels
{
    public class PitcherSearchViewModel : ViewModelBase
    {
        private ObservableCollection<PitcherViewModel> _pitchers { get; set; }
        public ObservableCollection<PitcherViewModel> Pitchers
        {
            get { return _pitchers; }
            set { _pitchers = value; RaisePropertyChanged("Pitchers"); }
        }

        public string LastName { get; set; } 

        public int Year { get; set; }

        public ObservableCollection<int> Years { get; set; }

        public IPlayerSearchService PlayerSearchService { get; set; }

        public PitcherSearchViewModel(IPlayerSearchServiceFactory playerSearchServiceFactory)
        {
            PlayerSearchService = playerSearchServiceFactory.GetPlayerSearchService(PlayerType.Pitcher);
            Years = new ObservableCollection<int>(Enumerable.Range(1871, 2019));
            Year = 2019;
        }

        public void SearchPitcherByLastNameAndYear()
        {
            Pitchers = new ObservableCollection<PitcherViewModel>(PlayerSearchService.SearchByLastNameAndYear(LastName, Year).Select(p => new PitcherViewModel(p)));
        }
    }
}
