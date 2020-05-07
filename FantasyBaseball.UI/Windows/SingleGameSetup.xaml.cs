using FantasyBaseball.UI.ViewModels;
using System.Windows;

namespace FantasyBaseball.UI.Windows
{
    /// <summary>
    /// Interaction logic for SingleGameSetup.xaml
    /// </summary>
    public partial class SingleGameSetup : Window
    {
        public IViewModelFactory ViewModelFactory { get; set; }

        public SingleGameSetup(IViewModelFactory viewModelFactory)
        {
            InitializeComponent();
            ViewModelFactory = viewModelFactory;
        }

        private void CreateTeamsButton_Click(object sender, RoutedEventArgs e)
        {
            var singleTeamSearch = new SingleGameTeamSelector(ViewModelFactory);
            this.Visibility = Visibility.Hidden;
            singleTeamSearch.ShowDialog();
            this.Close();
        }
    }
}
