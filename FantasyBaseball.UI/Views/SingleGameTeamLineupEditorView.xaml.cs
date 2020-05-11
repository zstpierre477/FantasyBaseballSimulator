using FantasyBaseball.UI.ViewModels;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Windows;

namespace FantasyBaseball.UI.Views
{
    /// <summary>
    /// Interaction logic for SingleGameTeamLineupEditor.xaml
    /// </summary>
    public partial class SingleGameTeamLineupEditorView : Window
    {
        private IViewModelFactory ViewModelFactory { get; set; }

        public SingleGameTeamLineupEditorView(IViewModelFactory viewModelFactory, TeamViewModel teamViewModel)
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
