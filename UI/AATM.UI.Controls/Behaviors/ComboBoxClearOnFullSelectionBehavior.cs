using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AATM.UI.Controls
{
    public static class ComboBoxClearOnFullSelectionBehavior
    {
        public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.RegisterAttached(
            "IsEnabled",
            typeof(bool),
            typeof(ComboBoxClearOnFullSelectionBehavior),
            new PropertyMetadata(false, OnIsEnabledChanged));

        /// <summary>
        /// Enables or disables clear-on-full-selection behavior for ComboBox.
        /// </summary>
        public static void SetIsEnabled(DependencyObject element, bool value) => element.SetValue(IsEnabledProperty, value);

        /// <summary>
        /// Gets whether clear-on-full-selection behavior is enabled for ComboBox.
        /// </summary>
        public static bool GetIsEnabled(DependencyObject element) => (bool)element.GetValue(IsEnabledProperty);

        public static readonly DependencyProperty ClearCommandProperty = DependencyProperty.RegisterAttached(
            "ClearCommand",
            typeof(ICommand),
            typeof(ComboBoxClearOnFullSelectionBehavior),
            new PropertyMetadata(null));

        /// <summary>
        /// Sets the ICommand to execute when clearing the ComboBox value.
        /// </summary>
        public static void SetClearCommand(DependencyObject element, ICommand value) => element.SetValue(ClearCommandProperty, value);

        /// <summary>
        /// Gets the ICommand to execute when clearing the ComboBox value.
        /// </summary>
        public static ICommand GetClearCommand(DependencyObject element) => (ICommand)element.GetValue(ClearCommandProperty);

        public static readonly DependencyProperty ClearCommandParameterProperty = DependencyProperty.RegisterAttached(
            "ClearCommandParameter",
            typeof(object),
            typeof(ComboBoxClearOnFullSelectionBehavior),
            new PropertyMetadata(null));

        /// <summary>
        /// Sets the command parameter for the clear command.
        /// </summary>
        public static void SetClearCommandParameter(DependencyObject element, object value) => element.SetValue(ClearCommandParameterProperty, value);

        /// <summary>
        /// Gets the command parameter for the clear command.
        /// </summary>
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

            // After text input, ensure bindings are updated
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

            // Ignore empty input (IME composition or non-character input)
            if (string.IsNullOrEmpty(e.Text)) return;

            var tb = combo.Template.FindName("PART_EditableTextBox", combo) as TextBox;
            if (tb == null) return;

            // Only clear when the entire text is selected, the TextBox actually has keyboard focus
            // (prevents clearing when the user merely clicks to open the dropdown), and the input is a printable char.
            if (!string.IsNullOrEmpty(tb.Text) && tb.SelectionLength == tb.Text.Length && tb.IsKeyboardFocusWithin)
            {
                var ch = e.Text[0];
                if (!char.IsControl(ch))
                {
                    ClearComboBoxValue(combo);
                }
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
                // Prevent SelectedValue/SelectedItem from restoring text:
                combo.SelectedItem = null;
                combo.SelectedValue = null;
                combo.GetBindingExpression(ComboBox.SelectedValueProperty)?.UpdateSource();

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

                // No selection: allow default deletion to happen but ensure SelectedValue doesn't restore text.
                // Defer clearing/update to run after the control's own processing to avoid interfering with default edit.
                combo.Dispatcher.BeginInvoke((Action)(() =>
                {
                    combo.SelectedItem = null;
                    combo.SelectedValue = null;
                    combo.GetBindingExpression(ComboBox.SelectedValueProperty)?.UpdateSource();
                    combo.GetBindingExpression(ComboBox.TextProperty)?.UpdateSource();
                }), System.Windows.Threading.DispatcherPriority.Input);
            }
        }

        private static void ClearComboBoxValue(ComboBox combo)
        {
            // Execute an optional ICommand instead of calling a concrete ViewModel method.
            var command = GetClearCommand(combo);
            var parameter = GetClearCommandParameter(combo) ?? combo.DataContext;

            if (command != null && command.CanExecute(parameter))
            {
                command.Execute(parameter);
            }

            // Ensure UI reflects changes
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
