using System;
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
            pageContentFrame.Source = new HomeView(viewModelFactory);
        }
    }
}
