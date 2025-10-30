using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FilteredComboBoxDemo
{
    public partial class MainWindow : Window
    {
        private List<string> _allItems;
        private bool _suppressTextChanged = false;

        public MainWindow()
        {
            InitializeComponent();

            // Full list of items to display in ComboBox
            _allItems = new List<string>
            {
                "Apple", "Apricot", "Avocado", "Banana", "Blackberry",
                "Blueberry", "Cherry", "Coconut", "Date", "Dragonfruit",
                "Grapes", "Guava", "Lemon", "Mango", "Orange",
                "Papaya", "Peach", "Pear", "Pineapple", "Watermelon"
            };

            // Initialize ComboBox items
            comboBox.ItemsSource = _allItems;

            // Events
            comboBox.PreviewKeyDown += ComboBox_PreviewKeyDown;
            comboBox.AddHandler(TextBox.TextChangedEvent, new TextChangedEventHandler(ComboBox_TextChanged));
        }

        // Filter the ComboBox items when the user types
        private void ComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_suppressTextChanged) return;

            string text = comboBox.Text ?? string.Empty;

            // You can change StartsWith to Contains for flexible filtering
            var filtered = _allItems
                .Where(i => i.StartsWith(text, StringComparison.InvariantCultureIgnoreCase))
                .ToList();

            _suppressTextChanged = true;
            comboBox.ItemsSource = filtered;
            comboBox.IsDropDownOpen = true;
            comboBox.Text = text;

            // Move caret to end of text
            var textBox = (TextBox)comboBox.Template.FindName("PART_EditableTextBox", comboBox);
            if (textBox != null)
            {
                textBox.SelectionStart = textBox.Text.Length;
                textBox.SelectionLength = 0;
            }

            _suppressTextChanged = false;
        }

        // Handle Up, Down, and Enter keys
        private void ComboBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                if (!comboBox.IsDropDownOpen)
                {
                    comboBox.IsDropDownOpen = true;
                }
                else
                {
                    int nextIndex = comboBox.SelectedIndex + 1;
                    if (nextIndex < comboBox.Items.Count)
                        comboBox.SelectedIndex = nextIndex;
                }
                e.Handled = true;
            }
            else if (e.Key == Key.Up)
            {
                int prevIndex = comboBox.SelectedIndex - 1;
                if (prevIndex >= 0)
                    comboBox.SelectedIndex = prevIndex;
                e.Handled = true;
            }
            else if (e.Key == Key.Enter && comboBox.SelectedItem != null)
            {
                comboBox.Text = comboBox.SelectedItem.ToString();
                comboBox.IsDropDownOpen = false;

                var textBox = (TextBox)comboBox.Template.FindName("PART_EditableTextBox", comboBox);
                if (textBox != null)
                    textBox.CaretIndex = comboBox.Text.Length;

                e.Handled = true;
            }
        }
    }
}
