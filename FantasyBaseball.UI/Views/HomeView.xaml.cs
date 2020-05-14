using FantasyBaseball.UI.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace FantasyBaseball.UI.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : Page
    {
        private IViewModelFactory ViewModelFactory { get; set; }

        public HomeView(IViewModelFactory viewModelFactory)
        {
            InitializeComponent();
            ViewModelFactory = viewModelFactory;
        }

        private void PlayBallButton_Click(object sender, RoutedEventArgs e)
        {
            /*
            var gameSelectorWindow = new GameSelectorView(ViewModelFactory);
            gameSelectorWindow.Show();
            Close();*/
        }
    }
}
