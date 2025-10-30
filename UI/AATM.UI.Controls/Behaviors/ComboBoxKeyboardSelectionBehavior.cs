using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AATM.UI.Controls
{
    // Simple attached behavior: when enabled, allow keyboard up/down to highlight items in the opened dropdown
    // and only commit selection on Enter or Tab. Works with editable ComboBox (preserves typed text while navigating).
    public static class ComboBoxKeyboardSelectionBehavior
    {
        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.RegisterAttached(
                "IsEnabled",
                typeof(bool),
                typeof(ComboBoxKeyboardSelectionBehavior),
                new PropertyMetadata(false, OnIsEnabledChanged));

        public static void SetIsEnabled(DependencyObject element, bool value)
            => element.SetValue(IsEnabledProperty, value);

        public static bool GetIsEnabled(DependencyObject element)
            => (bool)element.GetValue(IsEnabledProperty);

        // Per-combo state
        private static readonly ConditionalWeakTable<ComboBox, ComboState> _states = new();

        private static void OnIsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not ComboBox cb) return;

            if ((bool)e.NewValue)
            {
                cb.DropDownOpened += Cb_DropDownOpened;
                cb.DropDownClosed += Cb_DropDownClosed;
            }
            else
            {
                cb.DropDownOpened -= Cb_DropDownOpened;
                cb.DropDownClosed -= Cb_DropDownClosed;
                RemoveState(cb);
            }
        }

        private static void Cb_DropDownOpened(object? sender, EventArgs e)
        {
            if (sender is not ComboBox cb) return;

            cb.ApplyTemplate();
            var tb = GetEditableTextBox(cb);

            var state = new ComboState
            {
                Combo = cb,
                SavedText = cb.Text ?? string.Empty
            };
            _states.Add(cb, state);

            if (tb != null)
            {
                tb.PreviewKeyDown -= TextBox_PreviewKeyDown;
                tb.PreviewKeyDown += TextBox_PreviewKeyDown;
            }

            cb.PreviewKeyDown -= Combo_PreviewKeyDown;
            cb.PreviewKeyDown += Combo_PreviewKeyDown;

            // Ensure an item is highlighted if there is a selection
            if (cb.SelectedIndex >= 0)
            {
                // leave selected index as-is (visual highlight will show)
            }
        }

        private static void Cb_DropDownClosed(object? sender, EventArgs e)
        {
            if (sender is not ComboBox cb) return;
            RemoveState(cb);
        }

        private static void RemoveState(ComboBox cb)
        {
            try
            {
                _states.Remove(cb);
            }
            catch { }

            var tb = GetEditableTextBox(cb);
            if (tb != null)
            {
                tb.PreviewKeyDown -= TextBox_PreviewKeyDown;
            }
            cb.PreviewKeyDown -= Combo_PreviewKeyDown;
        }

        private static void Combo_PreviewKeyDown(object? sender, KeyEventArgs e)
        {
            if (sender is not ComboBox cb) return;
            HandleNavigationAndCommit(cb, e);
        }

        private static void TextBox_PreviewKeyDown(object? sender, KeyEventArgs e)
        {
            if (sender is not TextBox tb) return;
            if (tb.TemplatedParent is not ComboBox cb) return;
            HandleNavigationAndCommit(cb, e);
        }

        private static void HandleNavigationAndCommit(ComboBox cb, KeyEventArgs e)
        {
            if (!_states.TryGetValue(cb, out var state)) return;

            // Up/Down: highlight next/previous without committing typed text
            if (e.Key == Key.Down || e.Key == Key.Up)
            {
                EnsureDropdownOpen(cb);
                NavigateHighlight(cb, e.Key == Key.Down ? 1 : -1);
                e.Handled = true;
                return;
            }

            // Enter: commit highlighted item (if any) and close dropdown
            if (e.Key == Key.Enter)
            {
                if (cb.SelectedIndex >= 0)
                {
                    CommitSelection(cb);
                    e.Handled = true;
                }
                return;
            }

            // Tab: commit but allow focus change
            if (e.Key == Key.Tab)
            {
                if (cb.SelectedIndex >= 0)
                {
                    CommitSelection(cb);
                }
                // do not mark handled so tab moves focus
            }

            // Escape: restore typed text and close dropdown
            if (e.Key == Key.Escape)
            {
                RestoreTypedText(cb);
                cb.IsDropDownOpen = false;
                e.Handled = true;
            }
        }

        private static void EnsureDropdownOpen(ComboBox cb)
        {
            if (!cb.IsDropDownOpen)
            {
                cb.IsDropDownOpen = true;
            }
        }

        private static void NavigateHighlight(ComboBox cb, int direction)
        {
            // Use visible items (cb.Items) which reflect any filtering applied (if itemsource was changed)
            var count = cb.Items.Count;
            if (count == 0) return;

            int idx = cb.SelectedIndex;
            if (idx < 0)
            {
                idx = direction > 0 ? 0 : count - 1;
            }
            else
            {
                idx = Math.Max(0, Math.Min(count - 1, idx + direction));
            }

            // Preserve typed text in editable textbox
            var tb = GetEditableTextBox(cb);
            var typed = tb?.Text ?? cb.Text ?? string.Empty;

            cb.SelectedIndex = idx;

            // Restore typed text so it does not get overwritten by SelectedItem text
            if (tb != null)
            {
                tb.Text = typed;
                tb.CaretIndex = tb.Text.Length;
                tb.Focus();
            }
            else
            {
                cb.Text = typed;
            }

            // keep dropdown open and ensure item visible
            cb.Dispatcher.BeginInvoke(new Action(() =>
            {
                try
                {
                    var container = cb.ItemContainerGenerator.ContainerFromIndex(idx) as FrameworkElement;
                    container?.BringIntoView();
                    cb.IsDropDownOpen = true;
                }
                catch { }
            }), System.Windows.Threading.DispatcherPriority.Background);
        }

        private static void CommitSelection(ComboBox cb)
        {
            if (cb.Items.Count == 0 || cb.SelectedIndex < 0) return;

            var item = cb.Items[cb.SelectedIndex];

            // set text based on DisplayMemberPath if present
            try
            {
                if (!string.IsNullOrEmpty(cb.DisplayMemberPath) && item != null)
                {
                    var prop = item.GetType().GetProperty(cb.DisplayMemberPath);
                    cb.Text = prop != null ? prop.GetValue(item)?.ToString() ?? string.Empty : item?.ToString() ?? string.Empty;
                }
                else
                {
                    cb.Text = item?.ToString() ?? string.Empty;
                }

                cb.SelectedItem = item;
            }
            catch { }

            cb.IsDropDownOpen = false;

            // restore focus to editable textbox and place caret at end
            var tb = GetEditableTextBox(cb);
            if (tb != null)
            {
                cb.Dispatcher.BeginInvoke(new Action(() =>
                {
                    try
                    {
                        tb.CaretIndex = tb.Text.Length;
                        tb.Focus();
                    }
                    catch { }
                }), System.Windows.Threading.DispatcherPriority.Background);
            }
        }

        private static void RestoreTypedText(ComboBox cb)
        {
            if (!_states.TryGetValue(cb, out var state)) return;
            var tb = GetEditableTextBox(cb);
            if (tb != null)
            {
                tb.Text = state.SavedText;
                tb.CaretIndex = tb.Text.Length;
                tb.Focus();
            }
            else
            {
                cb.Text = state.SavedText;
            }
        }

        private static TextBox? GetEditableTextBox(ComboBox comboBox)
        {
            if (!comboBox.IsEditable) return null;
            comboBox.ApplyTemplate();
            return comboBox.Template.FindName("PART_EditableTextBox", comboBox) as TextBox;
        }

        private class ComboState
        {
            public ComboBox? Combo;
            public string SavedText = string.Empty;
        }
    }
}