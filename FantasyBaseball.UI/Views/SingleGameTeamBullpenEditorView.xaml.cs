using FantasyBaseball.UI.ViewModels;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Windows;

namespace FantasyBaseball.UI.Views
{
    /// <summary>
    /// Interaction logic for SingleGameTeamBullpenEditor.xaml
    /// </summary>
    public partial class SingleGameTeamBullpenEditorView : Window
    {
        private IViewModelFactory ViewModelFactory { get; set; }

        public SingleGameTeamBullpenEditorView(IViewModelFactory viewModelFactory, TeamViewModel teamViewModel)
        {
            InitializeComponent();
            ViewModelFactory = viewModelFactory;
            DataContext = viewModelFactory.GetViewModel(GetType().ToString(), new List<ViewModelBase> { teamViewModel });
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
