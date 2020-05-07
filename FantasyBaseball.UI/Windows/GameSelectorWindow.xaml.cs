using FantasyBaseball.UI.ViewModels;
using System.Windows;

namespace FantasyBaseball.UI.Windows
{
    /// <summary>
    /// Interaction logic for GameSelector.xaml
    /// </summary>
    public partial class GameSelectorWindow : Window
    {
        private IViewModelFactory ViewModelFactory { get; set; }

        public GameSelectorWindow(IViewModelFactory viewModelFactory) 
        {
            InitializeComponent();
            ViewModelFactory = viewModelFactory;
        }

        private void SingleGameButton_Click(object sender, RoutedEventArgs e)
        {
            var singleGame = new SingleGameSetup(ViewModelFactory);
            singleGame.Show();
            this.Close();
        }
    }
}
