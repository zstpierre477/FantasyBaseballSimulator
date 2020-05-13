using FantasyBaseball.UI.ViewModels;
using System.Windows;

namespace FantasyBaseball.UI.Views
{
    /// <summary>
    /// Interaction logic for GameSelector.xaml
    /// </summary>
    public partial class GameSelectorView : Window
    {
        private IViewModelFactory ViewModelFactory { get; set; }

        public GameSelectorView(IViewModelFactory viewModelFactory) 
        {
            InitializeComponent();
            ViewModelFactory = viewModelFactory;
        }

        private void SingleGameButton_Click(object sender, RoutedEventArgs e)
        {
            var singleGame = new SingleGameSetupView(ViewModelFactory);
            singleGame.Show();
            Close();
        }

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
