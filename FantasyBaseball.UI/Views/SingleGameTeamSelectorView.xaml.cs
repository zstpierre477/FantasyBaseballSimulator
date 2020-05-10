using FantasyBaseball.UI.ViewModels;
using System.Windows;

namespace FantasyBaseball.UI.Views
{
    /// <summary>
    /// Interaction logic for SingleGameTeamSelector.xaml
    /// </summary>
    public partial class SingleGameTeamSelectorView : Window
    {
        private IViewModelFactory ViewModelFactory { get; set; }

        public SingleGameTeamSelectorView(IViewModelFactory viewModelFactory, bool generateRandomTeams = false)
        {
            InitializeComponent();
            ViewModelFactory = viewModelFactory;
            var vm = (SingleGameTeamSelectorViewModel)viewModelFactory.GetViewModel(GetType().ToString());
            if (generateRandomTeams)
            {
                vm.GenerateRandomTeams();
            }
            DataContext = vm;
        }

        private void startGameButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (SingleGameTeamSelectorViewModel)DataContext;
            if (viewModel.CanPlaySingleGame())
            {
                var singleGame = new SingleGameView(ViewModelFactory, viewModel);
                singleGame.Show();
                Close();
            }
            else
            {
                MessageBox.Show("To play a game, you must select a Team Name, Catcher, First Baseman, Second Baseman, Third Baseman, Shortstop, Left Fielder, " +
                    "Center Fielder, Right Fielder, Designated Hitter, and Starting Pitcher 1 for each team.");
            }
        }

        private BatterViewModel searchBatter()
        {
            var batterSearch = new BatterSearchView(ViewModelFactory);
            if (batterSearch.ShowDialog() == true)
            {
                return batterSearch.SelectedBatter;
            }
            return null;
        }

        private PitcherViewModel searchPitcher()
        {
            var pitcherSearch = new PitcherSearchView(ViewModelFactory);
            if (pitcherSearch.ShowDialog() == true)
            {
                return pitcherSearch.SelectedPitcher;
            }
            return null;
        }

        private void homeTeamCatcherButton_Click(object sender, RoutedEventArgs e)
        {
            var batter = searchBatter();
            if (batter != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.HomeTeam.Catcher = batter;
            }
        }

        private void homeTeamFirstBasemanButton_Click(object sender, RoutedEventArgs e)
        {
            var batter = searchBatter();
            if (batter != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.HomeTeam.FirstBaseman = batter;
            }
        }

        private void homeTeamSecondBasemanButton_Click(object sender, RoutedEventArgs e)
        {
            var batter = searchBatter();
            if (batter != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.HomeTeam.SecondBaseman = batter;
            }
        }

        private void homeTeamThirdBasemanButton_Click(object sender, RoutedEventArgs e)
        {
            var batter = searchBatter();
            if (batter != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.HomeTeam.ThirdBaseman = batter;
            }
        }

        private void homeTeamShortstopButton_Click(object sender, RoutedEventArgs e)
        {
            var batter = searchBatter();
            if (batter != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.HomeTeam.Shortstop = batter;
            }
        }

        private void homeTeamLeftFielderButton_Click(object sender, RoutedEventArgs e)
        {
            var batter = searchBatter();
            if (batter != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.HomeTeam.LeftFielder = batter;
            }
        }

        private void homeTeamCenterFielderButton_Click(object sender, RoutedEventArgs e)
        {
            var batter = searchBatter();
            if (batter != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.HomeTeam.CenterFielder = batter;
            }
        }

        private void homeTeamRightFielderButton_Click(object sender, RoutedEventArgs e)
        {
            var batter = searchBatter();
            if (batter != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.HomeTeam.RightFielder = batter;
            }
        }

        private void homeTeamDesignatedHitterButton_Click(object sender, RoutedEventArgs e)
        {
            var batter = searchBatter();
            if (batter != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.HomeTeam.DesignatedHitter = batter;
            }
        }

        private void homeTeamBenchPlayer1Button_Click(object sender, RoutedEventArgs e)
        {
            var batter = searchBatter();
            if (batter != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.HomeTeam.BenchPlayer1 = batter;
            }
        }

        private void homeTeamBenchPlayer2Button_Click(object sender, RoutedEventArgs e)
        {
            var batter = searchBatter();
            if (batter != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.HomeTeam.BenchPlayer2 = batter;
            }
        }

        private void homeTeamBenchPlayer3Button_Click(object sender, RoutedEventArgs e)
        {
            var batter = searchBatter();
            if (batter != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.HomeTeam.BenchPlayer3 = batter;
            }
        }

        private void homeTeamBenchPlayer4Button_Click(object sender, RoutedEventArgs e)
        {
            var batter = searchBatter();
            if (batter != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.HomeTeam.BenchPlayer4 = batter;
            }
        }

        private void homeTeamStartingPitcher1Button_Click(object sender, RoutedEventArgs e)
        {
            var pitcher = searchPitcher();
            if (pitcher != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.HomeTeam.StartingPitcher1 = pitcher;
            }
        }

        private void homeTeamStartingPitcher2Button_Click(object sender, RoutedEventArgs e)
        {
            var pitcher = searchPitcher();
            if (pitcher != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.HomeTeam.StartingPitcher2 = pitcher;
            }
        }

        private void homeTeamStartingPitcher3Button_Click(object sender, RoutedEventArgs e)
        {
            var pitcher = searchPitcher();
            if (pitcher != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.HomeTeam.StartingPitcher3 = pitcher;
            }
        }

        private void homeTeamStartingPitcher4Button_Click(object sender, RoutedEventArgs e)
        {
            var pitcher = searchPitcher();
            if (pitcher != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.HomeTeam.StartingPitcher4 = pitcher;
            }
        }

        private void homeTeamStartingPitcher5Button_Click(object sender, RoutedEventArgs e)
        {
            var pitcher = searchPitcher();
            if (pitcher != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.HomeTeam.StartingPitcher5 = pitcher;
            }
        }

        private void homeTeamReliefPitcher1Button_Click(object sender, RoutedEventArgs e)
        {
            var pitcher = searchPitcher();
            if (pitcher != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.HomeTeam.ReliefPitcher1 = pitcher;
            }
        }

        private void homeTeamReliefPitcher2Button_Click(object sender, RoutedEventArgs e)
        {
            var pitcher = searchPitcher();
            if (pitcher != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.HomeTeam.ReliefPitcher2 = pitcher;
            }
        }

        private void homeTeamReliefPitcher3Button_Click(object sender, RoutedEventArgs e)
        {
            var pitcher = searchPitcher();
            if (pitcher != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.HomeTeam.ReliefPitcher3 = pitcher;
            }
        }

        private void homeTeamReliefPitcher4Button_Click(object sender, RoutedEventArgs e)
        {
            var pitcher = searchPitcher();
            if (pitcher != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.HomeTeam.ReliefPitcher4 = pitcher;
            }
        }

        private void homeTeamReliefPitcher5Button_Click(object sender, RoutedEventArgs e)
        {
            var pitcher = searchPitcher();
            if (pitcher != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.HomeTeam.ReliefPitcher5 = pitcher;
            }
        }

        private void homeTeamReliefPitcher6Button_Click(object sender, RoutedEventArgs e)
        {
            var pitcher = searchPitcher();
            if (pitcher != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.HomeTeam.ReliefPitcher6 = pitcher;
            }
        }

        private void homeTeamReliefPitcher7Button_Click(object sender, RoutedEventArgs e)
        {
            var pitcher = searchPitcher();
            if (pitcher != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.HomeTeam.ReliefPitcher7 = pitcher;
            }
        }

        private void awayTeamCatcherButton_Click(object sender, RoutedEventArgs e)
        {
            var batter = searchBatter();
            if (batter != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.AwayTeam.Catcher = batter;
            }
        }

        private void awayTeamFirstBasemanButton_Click(object sender, RoutedEventArgs e)
        {
            var batter = searchBatter();
            if (batter != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.AwayTeam.FirstBaseman = batter;
            }
        }

        private void awayTeamSecondBasemanButton_Click(object sender, RoutedEventArgs e)
        {
            var batter = searchBatter();
            if (batter != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.AwayTeam.SecondBaseman = batter;
            }
        }

        private void awayTeamThirdBasemanButton_Click(object sender, RoutedEventArgs e)
        {
            var batter = searchBatter();
            if (batter != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.AwayTeam.ThirdBaseman = batter;
            }
        }

        private void awayTeamShortstopButton_Click(object sender, RoutedEventArgs e)
        {
            var batter = searchBatter();
            if (batter != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.AwayTeam.Shortstop = batter;
            }
        }

        private void awayTeamLeftFielderButton_Click(object sender, RoutedEventArgs e)
        {
            var batter = searchBatter();
            if (batter != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.AwayTeam.LeftFielder = batter;
            }
        }

        private void awayTeamCenterFielderButton_Click(object sender, RoutedEventArgs e)
        {
            var batter = searchBatter();
            if (batter != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.AwayTeam.CenterFielder = batter;
            }
        }

        private void awayTeamRightFielderButton_Click(object sender, RoutedEventArgs e)
        {
            var batter = searchBatter();
            if (batter != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.AwayTeam.RightFielder = batter;
            }
        }

        private void awayTeamDesignatedHitterButton_Click(object sender, RoutedEventArgs e)
        {
            var batter = searchBatter();
            if (batter != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.AwayTeam.DesignatedHitter = batter;
            }
        }

        private void awayTeamBenchPlayer1Button_Click(object sender, RoutedEventArgs e)
        {
            var batter = searchBatter();
            if (batter != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.AwayTeam.BenchPlayer1 = batter;
            }
        }

        private void awayTeamBenchPlayer2Button_Click(object sender, RoutedEventArgs e)
        {
            var batter = searchBatter();
            if (batter != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.AwayTeam.BenchPlayer2 = batter;
            }
        }

        private void awayTeamBenchPlayer3Button_Click(object sender, RoutedEventArgs e)
        {
            var batter = searchBatter();
            if (batter != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.AwayTeam.BenchPlayer3 = batter;
            }
        }

        private void awayTeamBenchPlayer4Button_Click(object sender, RoutedEventArgs e)
        {
            var batter = searchBatter();
            if (batter != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.AwayTeam.BenchPlayer4 = batter;
            }
        }

        private void awayTeamStartingPitcher1Button_Click(object sender, RoutedEventArgs e)
        {
            var pitcher = searchPitcher();
            if (pitcher != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.AwayTeam.StartingPitcher1 = pitcher;
            }
        }

        private void awayTeamStartingPitcher2Button_Click(object sender, RoutedEventArgs e)
        {
            var pitcher = searchPitcher();
            if (pitcher != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.AwayTeam.StartingPitcher2 = pitcher;
            }
        }

        private void awayTeamStartingPitcher3Button_Click(object sender, RoutedEventArgs e)
        {
            var pitcher = searchPitcher();
            if (pitcher != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.AwayTeam.StartingPitcher3 = pitcher;
            }
        }

        private void awayTeamStartingPitcher4Button_Click(object sender, RoutedEventArgs e)
        {
            var pitcher = searchPitcher();
            if (pitcher != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.AwayTeam.StartingPitcher4 = pitcher;
            }
        }

        private void awayTeamStartingPitcher5Button_Click(object sender, RoutedEventArgs e)
        {
            var pitcher = searchPitcher();
            if (pitcher != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.AwayTeam.StartingPitcher5 = pitcher;
            }
        }

        private void awayTeamReliefPitcher1Button_Click(object sender, RoutedEventArgs e)
        {
            var pitcher = searchPitcher();
            if (pitcher != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.AwayTeam.ReliefPitcher1 = pitcher;
            }
        }

        private void awayTeamReliefPitcher2Button_Click(object sender, RoutedEventArgs e)
        {
            var pitcher = searchPitcher();
            if (pitcher != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.AwayTeam.ReliefPitcher2 = pitcher;
            }
        }

        private void awayTeamReliefPitcher3Button_Click(object sender, RoutedEventArgs e)
        {
            var pitcher = searchPitcher();
            if (pitcher != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.AwayTeam.ReliefPitcher3 = pitcher;
            }
        }

        private void awayTeamReliefPitcher4Button_Click(object sender, RoutedEventArgs e)
        {
            var pitcher = searchPitcher();
            if (pitcher != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.AwayTeam.ReliefPitcher4 = pitcher;
            }
        }

        private void awayTeamReliefPitcher5Button_Click(object sender, RoutedEventArgs e)
        {
            var pitcher = searchPitcher();
            if (pitcher != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.AwayTeam.ReliefPitcher5 = pitcher;
            }
        }

        private void awayTeamReliefPitcher6Button_Click(object sender, RoutedEventArgs e)
        {
            var pitcher = searchPitcher();
            if (pitcher != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.AwayTeam.ReliefPitcher6 = pitcher;
            }
        }

        private void awayTeamReliefPitcher7Button_Click(object sender, RoutedEventArgs e)
        {
            var pitcher = searchPitcher();
            if (pitcher != null)
            {
                var vm = (SingleGameTeamSelectorViewModel)DataContext;
                vm.AwayTeam.ReliefPitcher7 = pitcher;
            }
        }
    }
}
