using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AATM.App.HisWpf.Behaviors
{
    public static class ComboBoxClearOnFullSelectionBehavior
    {
        public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.RegisterAttached(
            "IsEnabled",
            typeof(bool),
            typeof(ComboBoxClearOnFullSelectionBehavior),
            new PropertyMetadata(false, OnIsEnabledChanged));

        public static void SetIsEnabled(DependencyObject element, bool value) => element.SetValue(IsEnabledProperty, value);
        public static bool GetIsEnabled(DependencyObject element) => (bool)element.GetValue(IsEnabledProperty);

        public static readonly DependencyProperty ClearCommandProperty = DependencyProperty.RegisterAttached(
            "ClearCommand",
            typeof(ICommand),
            typeof(ComboBoxClearOnFullSelectionBehavior),
            new PropertyMetadata(null));

        public static void SetClearCommand(DependencyObject element, ICommand value) => element.SetValue(ClearCommandProperty, value);
        public static ICommand GetClearCommand(DependencyObject element) => (ICommand)element.GetValue(ClearCommandProperty);

        public static readonly DependencyProperty ClearCommandParameterProperty = DependencyProperty.RegisterAttached(
            "ClearCommandParameter",
            typeof(object),
            typeof(ComboBoxClearOnFullSelectionBehavior),
            new PropertyMetadata(null));

        public static void SetClearCommandParameter(DependencyObject element, object value) => element.SetValue(ClearCommandParameterProperty, value);
        public static object GetClearCommandParameter(DependencyObject element) => element.GetValue(ClearCommandParameterProperty);

        private static void OnIsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not ComboBox combo) return;

            if ((bool)e.NewValue)
            {
                combo.PreviewKeyDown += Combo_PreviewKeyDown;
                combo.PreviewTextInput += Combo_PreviewTextInput;
                combo.TextInput += Combo_TextInput;
                combo.LostFocus += Combo_LostFocus;
            }
            else
            {
                combo.PreviewKeyDown -= Combo_PreviewKeyDown;
                combo.PreviewTextInput -= Combo_PreviewTextInput;
                combo.TextInput -= Combo_TextInput;
                combo.LostFocus -= Combo_LostFocus;
            }
        }

        private static void Combo_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (sender is not ComboBox combo || !combo.IsEditable) return;

            var beText = combo.GetBindingExpression(ComboBox.TextProperty);
            beText?.UpdateSource();
        }

        private static void Combo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is not ComboBox combo) return;

            if (string.IsNullOrEmpty(combo.Text))
            {
                ClearComboBoxValue(combo);
            }
        }

        private static void Combo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (sender is not ComboBox combo || !combo.IsEditable) return;

            var tb = combo.Template.FindName("PART_EditableTextBox", combo) as TextBox;
            if (tb == null) return;

            if (!string.IsNullOrEmpty(tb.Text) && tb.SelectionLength == tb.Text.Length)
            {
                ClearComboBoxValue(combo);
            }
        }

        private static void Combo_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (sender is not ComboBox combo || !combo.IsEditable) return;

            var tb = combo.Template.FindName("PART_EditableTextBox", combo) as TextBox;
            if (tb == null) return;

            // Handle Delete or Backspace
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                // If some text is selected, remove it immediately and update bindings
                if (tb.SelectionLength > 0)
                {
                    var start = tb.SelectionStart;
                    tb.Text = tb.Text.Remove(start, tb.SelectionLength);
                    tb.SelectionStart = start;
                    tb.SelectionLength = 0;

                    combo.GetBindingExpression(ComboBox.TextProperty)?.UpdateSource();
                    e.Handled = true; // we handled the edit
                    return;
                }

                // No selection: allow default deletion to happen; after control processes the key
                // update the Text binding and only clear SelectedValue if the text became empty.
                combo.Dispatcher.BeginInvoke((Action)(() =>
                {
                    // First update Text binding so VM sees the new typed value
                    combo.GetBindingExpression(ComboBox.TextProperty)?.UpdateSource();

                    try
                    {
                        var tb2 = combo.Template.FindName("PART_EditableTextBox", combo) as TextBox;
                        var currentText = (tb2?.Text) ?? combo.Text ?? string.Empty;

                        // If user deleted to empty string, clear the selection/value to avoid restore from SelectedValue binding
                        if (string.IsNullOrEmpty(currentText))
                        {
                            combo.SelectedItem = null;
                            combo.SelectedValue = null;
                            combo.GetBindingExpression(ComboBox.SelectedValueProperty)?.UpdateSource();
                        }
                    }
                    catch { /* defensive: do not crash UI on reflection/template issues */ }
                }), System.Windows.Threading.DispatcherPriority.Input);
            }
        }

        private static void ClearComboBoxValue(ComboBox combo)
        {
            var command = GetClearCommand(combo);
            var parameter = GetClearCommandParameter(combo) ?? combo.DataContext;

            if (command != null && command.CanExecute(parameter))
            {
                command.Execute(parameter);
            }

            combo.Text = string.Empty;
            combo.SelectedItem = null;
            combo.SelectedValue = null;

            var textBinding = combo.GetBindingExpression(ComboBox.TextProperty);
            var valueBinding = combo.GetBindingExpression(ComboBox.SelectedValueProperty);

            textBinding?.UpdateSource();
            valueBinding?.UpdateSource();
        }
    }
}