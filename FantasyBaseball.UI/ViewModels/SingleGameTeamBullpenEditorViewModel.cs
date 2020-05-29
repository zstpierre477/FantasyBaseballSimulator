using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.VisualStudio.PlatformUI;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace FantasyBaseball.UI.ViewModels
{
    public class SingleGameTeamBullpenEditorViewModel : ViewModelBase
    {
        public TeamViewModel Team { get; set; }

        private DelegateCommand _switchPitcherCommand { get; set; }
        public DelegateCommand SwitchPitcherCommand
        {
            get { return _switchPitcherCommand; }
            set { _switchPitcherCommand = value; }
        }

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

        private bool _isGameStarted { get; set; }
        public bool IsGameStarted
        {
            get { return _isGameStarted; }
            set { _isGameStarted = value; RaisePropertyChanged("IsGameStarted"); _switchPitcherCommand.RaiseCanExecuteChanged(); }
        }

        public SingleGameTeamBullpenEditorViewModel(TeamViewModel teamViewModel)
        {
            SwitchPitcherCommand = new DelegateCommand(SwitchPitcher, CanSwitchPitcher);
            Team = teamViewModel;
            if (Team.Bullpen.Count() > 0)
            {
                SelectedBullpenPitcher = Team.Bullpen.ElementAt(0);
            }
            IsGameStarted = false;
        }

        private void SwitchPitcher()
        {
            var currentPitcher = Team.CurrentPitcher;
            if (IsGameStarted == false)
            {
                Team.CurrentPitcher = Team.Bullpen[SelectedBullpenPitcher.BullpenIndex.Value];
                Team.Bullpen[SelectedBullpenPitcher.BullpenIndex.Value] = currentPitcher;
                SelectedBullpenPitcher = currentPitcher;
                SelectedBullpenPitcher.BullpenIndex = Team.CurrentPitcher.BullpenIndex;
                Team.CurrentPitcher.BullpenIndex = null;
            }
            else
            {
                Team.CurrentPitcher = SelectedBullpenPitcher;
                Team.Bullpen.Remove(Team.CurrentPitcher);
                Team.UsedPitchers.Add(currentPitcher);
            }
            RaisePropertyChanged("CurrentPitcher");
        }

        private bool CanSwitchPitcher()
        {
            return Team.CurrentPitcher != null && SelectedBullpenPitcher != null;
        }
    }
}
