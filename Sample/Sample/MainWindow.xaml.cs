using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private readonly List<string> _masterList = new()
        {
            "Apple","Apricot","Avocado","Banana","Blackberry","Blueberry",
            "Cherry","Coconut","Date","Fig","Grape","Guava","Kiwi",
            "Lemon","Lime","Mango","Melon","Orange","Papaya","Peach",
            "Pear","Pineapple","Plum","Raspberry","Strawberry","Watermelon"
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            string input = txtFilter.Text.Trim();

            var filtered = _masterList
                .Where(x => x.Contains(input, StringComparison.OrdinalIgnoreCase))
                .ToList();

            lstSuggestions.ItemsSource = filtered;

            // Automatically open dropdown if there are results
            borderSuggestions.Visibility = filtered.Any() ? Visibility.Visible : Visibility.Collapsed;

            if (filtered.Any())
                lstSuggestions.SelectedIndex = 0;
        }

        private void txtFilter_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down && lstSuggestions.Visibility == Visibility.Visible && lstSuggestions.Items.Count > 0)
            {
                e.Handled = true;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    lstSuggestions.Focus();
                    lstSuggestions.SelectedIndex = 0;

                    if (lstSuggestions.ItemContainerGenerator.ContainerFromIndex(0) is ListBoxItem item)
                        item.Focus();
                }), DispatcherPriority.Input);
            }
            else if (e.Key == Key.Escape)
            {
                borderSuggestions.Visibility = Visibility.Collapsed;
                e.Handled = true;
            }
        }

        private void lstSuggestions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && lstSuggestions.SelectedItem != null)
            {
                txtFilter.Text = lstSuggestions.SelectedItem.ToString();
                borderSuggestions.Visibility = Visibility.Collapsed;
                txtFilter.CaretIndex = txtFilter.Text.Length;
                txtFilter.Focus();
                e.Handled = true;
            }
            else if (e.Key == Key.Escape)
            {
                borderSuggestions.Visibility = Visibility.Collapsed;
                txtFilter.Focus();
                e.Handled = true;
            }
        }

        private void lstSuggestions_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lstSuggestions.SelectedItem != null)
            {
                txtFilter.Text = lstSuggestions.SelectedItem.ToString();
                borderSuggestions.Visibility = Visibility.Collapsed;
                txtFilter.Focus();
                txtFilter.CaretIndex = txtFilter.Text.Length;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!borderSuggestions.IsMouseOver && !txtFilter.IsMouseOver)
                borderSuggestions.Visibility = Visibility.Collapsed;
        }
    }
}
