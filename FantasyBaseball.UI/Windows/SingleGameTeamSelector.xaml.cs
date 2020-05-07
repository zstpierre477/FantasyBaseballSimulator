using FantasyBaseball.UI.ViewModels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace FantasyBaseball.UI.Windows
{
    /// <summary>
    /// Interaction logic for SingleGameTeamSelector.xaml
    /// </summary>
    public partial class SingleGameTeamSelector : Window
    {
        private IViewModelFactory ViewModelFactory { get; set; }

        public SingleGameTeamSelector(IViewModelFactory viewModelFactory)
        {
            InitializeComponent();
            ViewModelFactory = viewModelFactory;
            DataContext = viewModelFactory.GetViewModel(GetType().ToString());
        }

        private void startGameButton_Click(object sender, RoutedEventArgs e)
        {
            var singleGame = new SingleGame(ViewModelFactory, (SingleGameTeamSelectorViewModel)DataContext);
            singleGame.Show();
            Close();
        }

        private void selectBatterButton_Click(object sender, RoutedEventArgs e)
        {
            var batterSearch = new BatterSearch(ViewModelFactory);
            if (batterSearch.ShowDialog() == true)
            {
                var button = (Button)sender;
                var expectedLabel = FindName(button.Name.Replace("Button","Label"));
                if (expectedLabel is Label)
                {
                    var label = expectedLabel as Label;

                    if (Batters.ContainsKey(label.Name))
                    {
                        Batters[label.Name] = batterSearch.SelectedBatter;
                    }
                    {
                        Batters.Add(label.Name, batterSearch.SelectedBatter);
                    }

                    label..Content = $"{batterSearch.SelectedBatter.FirstName} {batterSearch.SelectedBatter.LastName} {batterSearch.SelectedBatter.Year} {batterSearch.SelectedBatter.TeamShortName}";
                }
            }
        }

        private void selectPitcherButton_Click(object sender, RoutedEventArgs e)
        {
            var pitcherSearch = new PitcherSearch(ViewModelFactory);
            if (pitcherSearch.ShowDialog() == true)
            {
                var button = (Button)sender;
                var expectedLabel = FindName(button.Name.Replace("Button", "Label"));
                if (expectedLabel is Label)
                {
                    var label = expectedLabel as Label;

                    if (Pitchers.ContainsKey(label.Name))
                    {
                        Pitchers[label.Name] = pitcherSearch.SelectedPitcher;
                    }
                    {
                        Pitchers.Add(label.Name, pitcherSearch.SelectedPitcher);
                    }

                    label.Content = $"{pitcherSearch.SelectedPitcher.FirstName} {pitcherSearch.SelectedPitcher.LastName} {pitcherSearch.SelectedPitcher.Year} {pitcherSearch.SelectedPitcher.TeamShortName}";
                }
            }
        }
    }
}
