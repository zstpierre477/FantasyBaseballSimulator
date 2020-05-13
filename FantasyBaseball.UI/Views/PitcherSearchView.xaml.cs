using FantasyBaseball.UI.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FantasyBaseball.UI.Views
{
    /// <summary>
    /// Interaction logic for PitcherSearch.xaml
    /// </summary>
    public partial class PitcherSearchView : Window
    {
        public PitcherViewModel SelectedPitcher { get; set; }

        public PitcherSearchView(IViewModelFactory viewModelFactory)
        {
            InitializeComponent();
            DataContext = viewModelFactory.GetViewModel(GetType().ToString());
        }

        private void pitcherSearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(pitcherLastNameTextBox.Text) || string.IsNullOrEmpty(yearTextBox.Text))
            {
                MessageBox.Show("You must fill in a player last name and year.");
                return;
            }

            if (int.TryParse(yearTextBox.Text, out var year) == false)
            {
                MessageBox.Show("Year must be a number.");
                return;
            }

            var viewModel = (PitcherSearchViewModel)DataContext;
            viewModel.SearchPitcherByLastNameAndYear();
        }

        private void dataGridButton_Click(object sender, RoutedEventArgs e)
        {
            var parent = VisualTreeHelper.GetParent((Visual)sender);
            while (!(parent is DataGridRow))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            var row = (DataGridRow)parent;

            SelectedPitcher = row.Item as PitcherViewModel;

            DialogResult = true;
            Close();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
