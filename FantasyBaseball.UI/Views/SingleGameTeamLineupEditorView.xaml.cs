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

        public SingleGameTeamLineupEditorView(IViewModelFactory viewModelFactory, TeamViewModel teamViewModel, bool isGameStarted = false, bool sortLineup = true)
        {
            InitializeComponent();
            ViewModelFactory = viewModelFactory;
            var viewModel = (SingleGameTeamLineupEditorViewModel)viewModelFactory.GetViewModel(GetType().ToString(), new List<ViewModelBase> { teamViewModel }, sortLineup);
            viewModel.IsGameStarted = isGameStarted;
            DataContext = viewModel;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
