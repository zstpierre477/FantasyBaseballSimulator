using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FantasyBaseball.UI.ViewModels
{
    public class SingleGameTeamBullpenEditorViewModel : ViewModelBase
    {
        public TeamViewModel Team { get; set; }

        public ICommand SwitchPitcherCommand { get; set; }

        public PitcherViewModel SelectedBullpenPitcher { get; set; }

        public int SelectedBullpenPitcherIndex { get; set; }

        public SingleGameTeamBullpenEditorViewModel(TeamViewModel teamViewModel)
        {
            SwitchPitcherCommand = new RelayCommand(SwitchPitcher, CanSwitchPitcher);

            if (teamViewModel.Bullpen == null)
            {
                teamViewModel.Bullpen = new ObservableCollection<PitcherViewModel>
                {
                    teamViewModel.StartingPitcher2,
                    teamViewModel.StartingPitcher3,
                    teamViewModel.StartingPitcher4,
                    teamViewModel.StartingPitcher5,
                    teamViewModel.ReliefPitcher1,
                    teamViewModel.ReliefPitcher2,
                    teamViewModel.ReliefPitcher3,
                    teamViewModel.ReliefPitcher4,
                    teamViewModel.ReliefPitcher5,
                    teamViewModel.ReliefPitcher6,
                    teamViewModel.ReliefPitcher7
                };
            }

            if (teamViewModel.CurrentPitcher == null)
            {
                teamViewModel.CurrentPitcher = teamViewModel.StartingPitcher1;
            }

            Team = teamViewModel;
        }

        private void SwitchPitcher()
        {
            var currentPitcher = Team.CurrentPitcher;
            Team.CurrentPitcher = Team.Bullpen[SelectedBullpenPitcherIndex];
            Team.Bullpen[SelectedBullpenPitcherIndex] = currentPitcher;
            SelectedBullpenPitcher = currentPitcher;
        }

        private bool CanSwitchPitcher()
        {
            return Team.CurrentPitcher != null && SelectedBullpenPitcher != null;
        }
    }
}
