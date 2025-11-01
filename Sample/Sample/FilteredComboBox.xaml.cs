using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp1
{
    public partial class FilteredComboBox : UserControl
    {
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(nameof(ItemsSource), typeof(IEnumerable<string>), typeof(FilteredComboBox),
                new PropertyMetadata(null));

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(FilteredComboBox),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public IEnumerable<string> ItemsSource
        {
            get => (IEnumerable<string>)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public event EventHandler<string>? ItemSelected;

        public FilteredComboBox()
        {
            InitializeComponent();
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            Text = txtFilter.Text;
            UpdateFilter();
        }

        private void UpdateFilter()
        {
            if (ItemsSource == null)
            {
                lstSuggestions.ItemsSource = null;
                popupSuggestions.IsOpen = false;
                return;
            }

            string filter = txtFilter.Text?.Trim() ?? string.Empty;
            var filtered = string.IsNullOrEmpty(filter)
                ? new List<string>() // show only when typing
                : ItemsSource.Where(i => i.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            lstSuggestions.ItemsSource = filtered;

            popupSuggestions.IsOpen = filtered.Any();
            if (filtered.Any())
                lstSuggestions.SelectedIndex = 0;
        }

        private void txtFilter_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down && lstSuggestions.Items.Count > 0)
            {
                e.Handled = true;
                popupSuggestions.IsOpen = true;
                lstSuggestions.Focus();
                lstSuggestions.SelectedIndex = 0;
                (lstSuggestions.ItemContainerGenerator.ContainerFromIndex(0) as ListBoxItem)?.Focus();
            }
            else if (e.Key == Key.Escape)
            {
                popupSuggestions.IsOpen = false;
                e.Handled = true;
            }
        }

        private void lstSuggestions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && lstSuggestions.SelectedItem != null)
            {
                CommitSelection();
                e.Handled = true;
            }
            else if (e.Key == Key.Escape)
            {
                popupSuggestions.IsOpen = false;
                txtFilter.Focus();
                e.Handled = true;
            }
        }

        private void lstSuggestions_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lstSuggestions.SelectedItem != null)
                CommitSelection();
        }

        private void CommitSelection()
        {
            if (lstSuggestions.SelectedItem is not string selected)
                return;

            txtFilter.Text = selected;
            popupSuggestions.IsOpen = false;
            txtFilter.CaretIndex = txtFilter.Text.Length;
            txtFilter.Focus();
            ItemSelected?.Invoke(this, selected);
        }
    }
}
