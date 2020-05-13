using FantasyBaseball.Entities.Models;
using FantasyBaseball.UI.ViewModels;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace FantasyBaseball.UI.Views
{
    /// <summary>
    /// Interaction logic for SingleGameSetup.xaml
    /// </summary>
    public partial class SingleGameSetupView : Window
    {
        public IViewModelFactory ViewModelFactory { get; set; }

        public SingleGameSetupView(IViewModelFactory viewModelFactory)
        {
            InitializeComponent();
            ViewModelFactory = viewModelFactory;
            DataContext = viewModelFactory.GetViewModel(GetType().ToString());
        }

        private void CreateTeamsButton_Click(object sender, RoutedEventArgs e)
        {
            var singleTeamSearch = new SingleGameTeamSelectorView(ViewModelFactory);
            Visibility = Visibility.Hidden;
            singleTeamSearch.ShowDialog();
            Close();
        }

        private void SelectHistoricalTeamsButton_Click(object sender, RoutedEventArgs e)
        {
            var vm = (SingleGameSetupViewModel)DataContext;
            if (vm.HistoricalTeams == null)
            {
                vm.ToggleLoading();
                Task.Run(() => LoadHistoricalTeams(vm));
            }
            else
            {
                vm.ToggleHistoricalTeamSelector();
            }
        }

        private void LoadHistoricalTeams(SingleGameSetupViewModel vm)
        {
            vm.LoadHistoricalTeams();
            Dispatcher.Invoke(() =>
            {
                vm.ToggleLoading();
                vm.ToggleHistoricalTeamSelector();
            });
        }

        private void SubmitHistoricalTeamsButton_Click(object sender, RoutedEventArgs e)
        {
            var vm = (SingleGameSetupViewModel)DataContext;
            vm.ToggleLoading();
            Task.Run(() => SubmitHistoricalTeams(vm));
        }

        private void SubmitHistoricalTeams(SingleGameSetupViewModel vm)
        {
            var teams = vm.AssembleHistoricalTeams();
            Dispatcher.Invoke(() =>
            {
                var singleGameTeamSelector = new SingleGameTeamSelectorView(ViewModelFactory, teams.First(), teams.ElementAt(1));
                singleGameTeamSelector.Show();
                Close();
            });
        }

        private void GenerateRandomTeamsButton_Click(object sender, RoutedEventArgs e)
        {
            var vm = (SingleGameSetupViewModel)DataContext;
            vm.ToggleLoading();
            Task.Run(() => GenerateRandomTeams(vm));
        }

        private void GenerateRandomTeams(SingleGameSetupViewModel vm)
        {
            var teams = vm.GenerateRandomTeams();
            Dispatcher.Invoke(() =>
            {
                var singleGameTeamSelector = new SingleGameTeamSelectorView(ViewModelFactory, teams.First(), teams.ElementAt(1));
                singleGameTeamSelector.Show();
                Close();
            });     
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            var gameSelectorWindow = new GameSelectorView(ViewModelFactory);
            gameSelectorWindow.Show();
            Close();
        }

        private void loadingGif_MediaEnded(object sender, RoutedEventArgs e)
        {
            loadingGif.Position = new TimeSpan(0, 0, 1);
            loadingGif.Play();
        }

        private void HistoricalTeamSelectorBackButton_Click(object sender, RoutedEventArgs e)
        {
            var vm = (SingleGameSetupViewModel)DataContext;
            vm.ToggleHistoricalTeamSelector();
        }
    }
}
