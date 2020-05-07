using FantasyBaseball.UI.ViewModels;
using System.Windows;

namespace FantasyBaseball.UI.Windows
{
    /// <summary>
    /// Interaction logic for SingleGame.xaml
    /// </summary>
    public partial class SingleGame : Window
    {
        public IViewModelFactory ViewModelFactory { get; set; }

        public SingleGame(IViewModelFactory viewModelFactory, SingleGameTeamSelectorViewModel singleGameTeamSelectorViewModel)
        {
            InitializeComponent();
            ViewModelFactory = viewModelFactory;
        }
    }
}
