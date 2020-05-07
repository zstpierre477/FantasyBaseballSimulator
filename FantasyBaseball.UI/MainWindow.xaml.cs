using FantasyBaseball.UI.Windows;
using System;
using System.Windows;
using FantasyBaseball.UI.ViewModels;

namespace FantasyBaseball.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private IViewModelFactory ViewModelFactory { get; set; }

        public MainWindow(IViewModelFactory viewModelFactory)
        {
            InitializeComponent();
            ViewModelFactory = viewModelFactory;
        }

        private void PlayBallButton_Click(object sender, RoutedEventArgs e)
        {
            var gameSelectorWindow = new GameSelectorWindow(ViewModelFactory);
            gameSelectorWindow.ShowDialog();
            Close();
        }
    }
}
