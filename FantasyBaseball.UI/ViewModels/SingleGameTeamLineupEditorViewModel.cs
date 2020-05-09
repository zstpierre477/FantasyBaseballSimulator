using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FantasyBaseball.UI.ViewModels
{
    public class SingleGameTeamLineupEditorViewModel : ViewModelBase
    {
        public TeamViewModel Team { get; set; }

        public ICommand SwitchInLineupCommand { get; set; }

        public ICommand MoveUpCommand { get; set; }

        public ICommand MoveDownCommand { get; set; }

        public BatterViewModel SelectedLineupBatter { get; set; }

        public int SelectedLineupBatterIndex { get; set; }

        public BatterViewModel SelectedBenchBatter { get; set; }

        public int SelectedBenchBatterIndex { get; set; }

        public SingleGameTeamLineupEditorViewModel(TeamViewModel teamViewModel)
        {
            SwitchInLineupCommand = new RelayCommand(SwitchInLineup, CanSwitchInLineup);
            MoveDownCommand = new RelayCommand(MoveDown, CanMoveDown);
            MoveUpCommand = new RelayCommand(MoveUp, CanMoveUp);

            if (teamViewModel.Lineup == null)
            {
                teamViewModel.Lineup = new ObservableCollection<BatterViewModel>
                {
                    teamViewModel.Catcher,
                    teamViewModel.FirstBaseman,
                    teamViewModel.SecondBaseman,
                    teamViewModel.ThirdBaseman,
                    teamViewModel.Shortstop,
                    teamViewModel.LeftFielder,
                    teamViewModel.CenterFielder,
                    teamViewModel.RightFielder,
                    teamViewModel.DesignatedHitter
                };
            }

            if (teamViewModel.Bench == null)
            {
                teamViewModel.Bench = new ObservableCollection<BatterViewModel>
                {
                    teamViewModel.BenchPlayer1,
                    teamViewModel.BenchPlayer2,
                    teamViewModel.BenchPlayer3,
                    teamViewModel.BenchPlayer4
                };
            }

            Team = teamViewModel;
        }

        private void SwitchInLineup()
        {
            var selectedLineupBatter = SelectedLineupBatter;
            Team.Bench[SelectedBenchBatterIndex] = SelectedLineupBatter;
            Team.Lineup[SelectedLineupBatterIndex] = SelectedBenchBatter;
            SelectedLineupBatter = SelectedBenchBatter;
            SelectedBenchBatter = selectedLineupBatter;
        }

        private void MoveDown()
        {
            Team.Lineup.Move(SelectedLineupBatterIndex, SelectedLineupBatterIndex+1);
        }

        private void MoveUp()
        {
            Team.Lineup.Move(SelectedLineupBatterIndex, SelectedLineupBatterIndex - 1);
        }

        private bool CanSwitchInLineup()
        {
            return SelectedBenchBatter != null && SelectedLineupBatter != null;
        }

        private bool CanMoveDown()
        {
            return SelectedLineupBatterIndex < 8;
        }

        private bool CanMoveUp()
        {
            return SelectedLineupBatterIndex > 0;
        }
    }
}
