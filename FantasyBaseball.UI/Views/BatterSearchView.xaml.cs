﻿using FantasyBaseball.UI.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FantasyBaseball.UI.Views
{
    /// <summary>
    /// Interaction logic for BatterSearch.xaml
    /// </summary>
    public partial class BatterSearchView : Window
    {
        public BatterViewModel SelectedBatter { get; set; }

        public BatterSearchView(IViewModelFactory viewModelFactory)
        {
            InitializeComponent();
            DataContext = viewModelFactory.GetViewModel(GetType().ToString());
        }

        private void batterSearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(batterLastNameTextBox.Text) || string.IsNullOrEmpty(yearTextBox.Text))
            {
                MessageBox.Show("You must fill in a player last name and year.");
                return;
            }

            if (int.TryParse(yearTextBox.Text, out var year) == false)
            {
                MessageBox.Show("Year must be a number.");
                return;
            }

            var viewModel = (BatterSearchViewModel)DataContext;
            viewModel.SearchBatterByLastNameAndYear();
        }

        private void dataGridButton_Click(object sender, RoutedEventArgs e)
        {
            var parent = VisualTreeHelper.GetParent((Visual)sender);
            while (!(parent is DataGridRow))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            var row = (DataGridRow)parent;

            SelectedBatter = row.Item as BatterViewModel;

            DialogResult = true;
            Close();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
