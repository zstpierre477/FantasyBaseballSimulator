using System;
using System.Threading.Tasks;
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
            DataContext = viewModelFactory.GetViewModel(GetType().ToString());
        }

        private void SingleGameButton_Click(object sender, RoutedEventArgs e)
        {
            var vm = (GameSelectorViewModel)DataContext;
            vm.ToggleLoading();
            Task.Run(() => LoadSingleGame(vm));
        }

        private void LoadSingleGame(GameSelectorViewModel vm)
        {
            vm.LoadDatabaseForSingleGame();
            Dispatcher.Invoke(() =>
            {
                vm.ToggleLoading();
                var singleGame = new SingleGameSetupView(ViewModelFactory);
                singleGame.Show();
                Close();
            });
        }

        private void loadingGif_MediaEnded(object sender, RoutedEventArgs e)
        {
            loadingGif.Position = new TimeSpan(0, 0, 1);
            loadingGif.Play();
        }

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
