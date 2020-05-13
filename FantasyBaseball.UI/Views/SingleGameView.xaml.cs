using FantasyBaseball.UI.ViewModels;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Windows;

namespace FantasyBaseball.UI.Views
{
    /// <summary>
    /// Interaction logic for SingleGame.xaml
    /// </summary>
    public partial class SingleGameView : Window
    {
        private IViewModelFactory ViewModelFactory { get; set; }

        public SingleGameView(IViewModelFactory viewModelFactory, SingleGameTeamSelectorViewModel singleGameTeamSelectorViewModel)
        {
            InitializeComponent();
            ViewModelFactory = viewModelFactory;
            var awayTeam = singleGameTeamSelectorViewModel.AwayTeam;
            var awayTeamLineupEditor = new SingleGameTeamLineupEditorView(viewModelFactory, awayTeam);
            awayTeamLineupEditor.ShowDialog();
            var awayTeamLineupEditorViewModel = (SingleGameTeamLineupEditorViewModel)awayTeamLineupEditor.DataContext;
            awayTeam = awayTeamLineupEditorViewModel.Team;
            var awayTeamBullpenEditor = new SingleGameTeamBullpenEditorView(viewModelFactory, awayTeam);
            awayTeamBullpenEditor.ShowDialog();
            var awayTeamBullpenEditorViewModel = (SingleGameTeamBullpenEditorViewModel)awayTeamBullpenEditor.DataContext;
            awayTeam = awayTeamBullpenEditorViewModel.Team;
            var homeTeam = singleGameTeamSelectorViewModel.HomeTeam;
            var homeTeamLineupEditor = new SingleGameTeamLineupEditorView(viewModelFactory, homeTeam);
            homeTeamLineupEditor.ShowDialog();
            var homeTeamLineupEditorViewModel = (SingleGameTeamLineupEditorViewModel)homeTeamLineupEditor.DataContext;
            homeTeam = homeTeamLineupEditorViewModel.Team;
            var homeTeamBullpenEditor = new SingleGameTeamBullpenEditorView(viewModelFactory, homeTeam);
            homeTeamBullpenEditor.ShowDialog();
            var homeTeamBullpenEditorViewModel = (SingleGameTeamBullpenEditorViewModel)homeTeamBullpenEditor.DataContext;
            homeTeam = homeTeamBullpenEditorViewModel.Team;
            DataContext = viewModelFactory.GetViewModel(GetType().ToString(), new List<ViewModelBase> { homeTeam, awayTeam });
        }

        private void homeTeamBenchButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (SingleGameViewModel)DataContext;
            var homeTeamLineupEditor = new SingleGameTeamLineupEditorView(ViewModelFactory, viewModel.HomeTeam, true);
            homeTeamLineupEditor.ShowDialog();
            var homeTeamLineupEditorViewModel = (SingleGameTeamLineupEditorViewModel)homeTeamLineupEditor.DataContext;
            var homeTeam = homeTeamLineupEditorViewModel.Team;
            viewModel.UpdateHomeTeamLineup(homeTeam);
        }

        private void homeTeamBullpenButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (SingleGameViewModel)DataContext;
            var homeTeamBullpenEditor = new SingleGameTeamBullpenEditorView(ViewModelFactory, viewModel.HomeTeam, true);
            homeTeamBullpenEditor.ShowDialog();
            var homeTeamBullpenEditorViewModel = (SingleGameTeamBullpenEditorViewModel)homeTeamBullpenEditor.DataContext;
            var homeTeam = homeTeamBullpenEditorViewModel.Team;
            viewModel.UpdateHomeTeamBullpen(homeTeam);
        }

        private void awayTeamBenchButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (SingleGameViewModel)DataContext;
            var awayTeamLineupEditor = new SingleGameTeamLineupEditorView(ViewModelFactory, viewModel.AwayTeam, true);
            awayTeamLineupEditor.ShowDialog();
            var awayTeamLineupEditorViewModel = (SingleGameTeamLineupEditorViewModel)awayTeamLineupEditor.DataContext;
            var awayTeam = awayTeamLineupEditorViewModel.Team;
            viewModel.UpdateAwayTeamLineup(awayTeam);
        }

        private void awayTeamBullpenButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (SingleGameViewModel)DataContext;
            var awayTeamBullpenEditor = new SingleGameTeamBullpenEditorView(ViewModelFactory, viewModel.AwayTeam, true);
            awayTeamBullpenEditor.ShowDialog();
            var awayTeamBullpenEditorViewModel = (SingleGameTeamBullpenEditorViewModel)awayTeamBullpenEditor.DataContext;
            var awayTeam = awayTeamBullpenEditorViewModel.Team;
            viewModel.UpdateAwayTeamBullpen(awayTeam);
        }

        private void returnToHomeScreenButton_Click(object sender, RoutedEventArgs e)
        {
            var main = new MainView(ViewModelFactory);
            main.Show();
            Close();
        }
    }
}
