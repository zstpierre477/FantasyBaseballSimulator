using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace FantasyBaseball.UI.ViewModels
{
    public class SingleGameTeamBullpenEditorViewModel : ViewModelBase
    {
        public TeamViewModel Team { get; set; }

        public ICommand SwitchPitcherCommand { get; set; }

        private PitcherViewModel _selectedBullpenPitcher { get; set; }
        public PitcherViewModel SelectedBullpenPitcher 
        { 
            get { return _selectedBullpenPitcher; }
            set { _selectedBullpenPitcher = value; RaisePropertyChanged("SelectedBullpenPitcher"); }
        }

        private ObservableCollection<PitcherViewModel> _currentPitcher => new ObservableCollection<PitcherViewModel> { Team.CurrentPitcher };
        public ObservableCollection<PitcherViewModel> CurrentPitcher
        {
            get { return _currentPitcher; }
        }

        public SingleGameTeamBullpenEditorViewModel(TeamViewModel teamViewModel)
        {
            SwitchPitcherCommand = new RelayCommand(SwitchPitcher, CanSwitchPitcher);
            Team = teamViewModel;
            if (Team.Bullpen.Count() > 0)
            {
                SelectedBullpenPitcher = Team.Bullpen.ElementAt(0);
            }
        }

        private void SwitchPitcher()
        {
            var currentPitcher = Team.CurrentPitcher;
            Team.CurrentPitcher = Team.Bullpen[SelectedBullpenPitcher.BullpenIndex.Value];
            Team.Bullpen[SelectedBullpenPitcher.BullpenIndex.Value] = currentPitcher;
            SelectedBullpenPitcher = currentPitcher;
            SelectedBullpenPitcher.BullpenIndex = Team.CurrentPitcher.BullpenIndex;
            Team.CurrentPitcher.BullpenIndex = null;
            RaisePropertyChanged("CurrentPitcher");
        }

        private bool CanSwitchPitcher()
        {
            return Team.CurrentPitcher != null && SelectedBullpenPitcher != null;
        }
    }
}
