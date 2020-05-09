using System.Windows;
using FantasyBaseball.UI.ViewModels;

namespace FantasyBaseball.UI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {

        private IViewModelFactory ViewModelFactory { get; set; }

        public MainView(IViewModelFactory viewModelFactory)
        {
            InitializeComponent();
            ViewModelFactory = viewModelFactory;
        }

        private void PlayBallButton_Click(object sender, RoutedEventArgs e)
        {
            var gameSelectorWindow = new GameSelectorView(ViewModelFactory);
            gameSelectorWindow.ShowDialog();
            Close();
        }
    }
}
