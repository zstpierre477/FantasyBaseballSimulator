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

        private Window AwayTeamLineupEditor { get; set; }

        private Window HomeTeamLineupEditor { get; set; }

        private Window AwayTeamBullpenEditor { get; set; }

        private Window HomeTeamBullpenEditor { get; set; }

        public SingleGameView(IViewModelFactory viewModelFactory, SingleGameTeamSelectorViewModel singleGameTeamSelectorViewModel)
        {
            InitializeComponent();
            ViewModelFactory = viewModelFactory;
            AwayTeamLineupEditor = new SingleGameTeamLineupEditorView(viewModelFactory, singleGameTeamSelectorViewModel.AwayTeam);
            AwayTeamLineupEditor.ShowDialog();
            var awayTeam = (TeamViewModel)AwayTeamLineupEditor.DataContext;
            AwayTeamBullpenEditor = new SingleGameTeamBullpenEditorView(viewModelFactory, awayTeam);
            AwayTeamBullpenEditor.ShowDialog();
            awayTeam = (TeamViewModel)AwayTeamBullpenEditor.DataContext;
            HomeTeamLineupEditor = new SingleGameTeamLineupEditorView(viewModelFactory, singleGameTeamSelectorViewModel.HomeTeam);
            HomeTeamLineupEditor.ShowDialog();
            var homeTeam = (TeamViewModel)HomeTeamLineupEditor.DataContext;
            HomeTeamBullpenEditor = new SingleGameTeamBullpenEditorView(viewModelFactory, homeTeam);
            HomeTeamBullpenEditor.ShowDialog();
            homeTeam = (TeamViewModel)HomeTeamBullpenEditor.DataContext;
            DataContext = viewModelFactory.GetViewModel(GetType().ToString(), new List<ViewModelBase> { homeTeam, awayTeam });
        }

        private void homeTeamBenchButton_Click(object sender, RoutedEventArgs e)
        {
            HomeTeamLineupEditor.ShowDialog();
            var homeTeam = (TeamViewModel)HomeTeamLineupEditor.DataContext;
            var viewModel = (SingleGameViewModel)DataContext;
            viewModel.UpdateHomeTeamLineup(homeTeam);
        }

        private void homeTeamBullpenButton_Click(object sender, RoutedEventArgs e)
        {
            HomeTeamBullpenEditor.ShowDialog();
            var homeTeam = (TeamViewModel)HomeTeamBullpenEditor.DataContext;
            var viewModel = (SingleGameViewModel)DataContext;
            viewModel.UpdateHomeTeamBullpen(homeTeam);
        }

        private void awayTeamBenchButton_Click(object sender, RoutedEventArgs e)
        {
            AwayTeamLineupEditor.ShowDialog();
            var awayTeam = (TeamViewModel)AwayTeamLineupEditor.DataContext;
            var viewModel = (SingleGameViewModel)DataContext;
            viewModel.UpdateAwayTeamLineup(awayTeam);
        }

        private void awayTeamBullpenButton_Click(object sender, RoutedEventArgs e)
        {
            AwayTeamBullpenEditor.ShowDialog();
            var awayTeam = (TeamViewModel)AwayTeamBullpenEditor.DataContext;
            var viewModel = (SingleGameViewModel)DataContext;
            viewModel.UpdateAwayTeamBullpen(awayTeam);
        }
    }
}
