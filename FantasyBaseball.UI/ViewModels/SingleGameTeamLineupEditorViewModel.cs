using GalaSoft.MvvmLight;
using Microsoft.VisualStudio.PlatformUI;
using System.Linq;

namespace FantasyBaseball.UI.ViewModels
{
    public class SingleGameTeamLineupEditorViewModel : ViewModelBase
    {
        public TeamViewModel Team { get; set; }

        private DelegateCommand _switchInLineupCommand { get; set; }
        public DelegateCommand SwitchInLineupCommand
        {
            get { return _switchInLineupCommand; }
            set { _switchInLineupCommand = value; }
        }

        private DelegateCommand _moveUpCommand { get; set; }
        public DelegateCommand MoveUpCommand
        {
            get { return _moveUpCommand; }
            set { _moveUpCommand = value; }
        }

        private DelegateCommand _moveDownCommand { get; set; }
        public DelegateCommand MoveDownCommand
        {
            get { return _moveDownCommand; }
            set { _moveDownCommand = value; }
        }

        private BatterViewModel _selectedLineupBatter { get; set; }
        public BatterViewModel SelectedLineupBatter
        {
            get { return _selectedLineupBatter; }
            set { _selectedLineupBatter = value; RaisePropertyChanged("SelectedLineupBatter"); _moveDownCommand.RaiseCanExecuteChanged(); _moveUpCommand.RaiseCanExecuteChanged(); _switchInLineupCommand.RaiseCanExecuteChanged(); }
        }

        private BatterViewModel _selectedBenchBatter { get; set; }
        public BatterViewModel SelectedBenchBatter
        {
            get { return _selectedBenchBatter; }
            set { _selectedBenchBatter = value; RaisePropertyChanged("SelectedBenchBatter"); }
        }

        private bool _isGameStarted { get; set; }
        public bool IsGameStarted
        {
            get { return _isGameStarted; }
            set { _isGameStarted = value; RaisePropertyChanged("IsGameStarted"); _moveDownCommand.RaiseCanExecuteChanged(); _moveUpCommand.RaiseCanExecuteChanged(); _switchInLineupCommand.RaiseCanExecuteChanged(); }
        }

        public SingleGameTeamLineupEditorViewModel(TeamViewModel teamViewModel)
        {
            SwitchInLineupCommand = new DelegateCommand(SwitchInLineup, CanSwitchInLineup);
            MoveDownCommand = new DelegateCommand(MoveDown, CanMoveDown);
            MoveUpCommand = new DelegateCommand(MoveUp, CanMoveUp);
            Team = teamViewModel;
            SelectedLineupBatter = Team.Lineup.ElementAt(0);
            if (Team.Bench.Count() > 0)
            {
                SelectedBenchBatter = Team.Bench.ElementAt(0);
            }
            IsGameStarted = false;
        }

        private void SwitchInLineup()
        {
            var selectedLineupBatter = SelectedLineupBatter;
            var selectedBenchBatter = SelectedBenchBatter;
            Team.Lineup[SelectedLineupBatter.CurrentGameLineupIndex.Value] = selectedBenchBatter;
            SelectedLineupBatter = selectedBenchBatter;
            SelectedLineupBatter.CurrentGameLineupIndex = selectedLineupBatter.CurrentGameLineupIndex;
            SelectedLineupBatter.CurrentGamePosition = selectedLineupBatter.CurrentGamePosition;
            if (IsGameStarted == false)
            {
                Team.Bench[selectedBenchBatter.CurrentGameBenchIndex.Value] = selectedLineupBatter;
                SelectedBenchBatter = selectedLineupBatter;
                SelectedBenchBatter.CurrentGameBenchIndex = selectedBenchBatter.CurrentGameBenchIndex;
                SelectedBenchBatter.CurrentGamePosition = null;
            }
            else
            {
                Team.Bench.RemoveAt(selectedBenchBatter.CurrentGameBenchIndex.Value);
                Team.UsedBatters.Add(selectedLineupBatter);
            }
            SelectedLineupBatter.CurrentGameBenchIndex = null;
        }

        private void MoveDown()
        {
            Team.Lineup.Move(SelectedLineupBatter.CurrentGameLineupIndex.Value, SelectedLineupBatter.CurrentGameLineupIndex.Value + 1);
            Team.Lineup[SelectedLineupBatter.CurrentGameLineupIndex.Value].CurrentGameLineupIndex--;
            Team.Lineup[SelectedLineupBatter.CurrentGameLineupIndex.Value + 1].CurrentGameLineupIndex++;
        }

        private void MoveUp()
        {
            Team.Lineup.Move(SelectedLineupBatter.CurrentGameLineupIndex.Value, SelectedLineupBatter.CurrentGameLineupIndex.Value - 1);
            Team.Lineup[SelectedLineupBatter.CurrentGameLineupIndex.Value].CurrentGameLineupIndex++;
            Team.Lineup[SelectedLineupBatter.CurrentGameLineupIndex.Value - 1].CurrentGameLineupIndex--;
        }

        private bool CanSwitchInLineup()
        {
            return SelectedBenchBatter != null && SelectedLineupBatter != null;
        }

        private bool CanMoveDown()
        {
            return IsGameStarted == false && (SelectedLineupBatter != null && SelectedLineupBatter.CurrentGameLineupIndex < 8);
        }

        private bool CanMoveUp()
        {
            return IsGameStarted == false && (SelectedLineupBatter != null && SelectedLineupBatter.CurrentGameLineupIndex > 0);
        }
    }
}
