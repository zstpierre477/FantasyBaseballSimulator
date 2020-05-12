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

        public SingleGameTeamBullpenEditorView(IViewModelFactory viewModelFactory, TeamViewModel teamViewModel, bool isGameStarted = false)
        {
            InitializeComponent();
            ViewModelFactory = viewModelFactory;
            var viewModel = (SingleGameTeamBullpenEditorViewModel)viewModelFactory.GetViewModel(GetType().ToString(), new List<ViewModelBase> { teamViewModel });
            viewModel.IsGameStarted = isGameStarted;
            DataContext = viewModel;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
