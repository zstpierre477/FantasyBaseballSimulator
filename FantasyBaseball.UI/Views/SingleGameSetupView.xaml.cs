using FantasyBaseball.UI.ViewModels;
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
        }

        private void CreateTeamsButton_Click(object sender, RoutedEventArgs e)
        {
            var singleTeamSearch = new SingleGameTeamSelectorView(ViewModelFactory);
            Visibility = Visibility.Hidden;
            singleTeamSearch.ShowDialog();
            Close();
        }

        private void GenerateRandomTeamsButton_Click(object sender, RoutedEventArgs e)
        {
            var singleTeamSearch = new SingleGameTeamSelectorView(ViewModelFactory, true);
            Visibility = Visibility.Hidden;
            singleTeamSearch.ShowDialog();
            Close();
        }
    }
}
