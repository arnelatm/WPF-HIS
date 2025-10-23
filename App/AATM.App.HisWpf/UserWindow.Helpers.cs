using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using AATM.Contracts.Dtos;

namespace AATM.App.HisWpf
{
    public partial class UserWindow
    {
        // Helper method to find child controls in the visual tree
        private static T? FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T typedChild)
                    return typedChild;

                var result = FindVisualChild<T>(child);
                if (result != null)
                    return result;
            }
            return null;
        }

        // Helper method to find parent controls in the visual tree
        private static T? FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(child);
            while (parent != null)
            {
                if (parent is T typedParent)
                    return typedParent;

                parent = VisualTreeHelper.GetParent(parent);
            }
            return null;
        }

        // Helper to clear a combo's temporary filter and refresh on the UI thread
        // Delegates the work to the reusable ComboBoxHelpers.
        private void ClearComboFilterAndRefresh(ComboBox combo, bool clearFilterText = false)
        {
            if (combo == null) return;

            // Delegate actual clearing/refresh to the reusable helper
            ComboBoxHelpers.ClearFilterAndRefresh(combo, clearFilterText);
        }

        private void EnsureDropDownOpen(ComboBox combo)
        {
            // Don't attempt to reopen if the combo helper is suppressing programmatic updates
            if (ComboBoxHelpers.IsSuppressingEnsureDropDownOpen(combo))
                return;

            // Only open when the user is focused in the control (avoid opening during initialization)
            if (!combo.IsKeyboardFocusWithin && !combo.IsFocused)
                return;

            if (combo.IsDropDownOpen) return;

            // Opening a popup synchronously while handling its Closed event throws:
            // "Cannot reopen a popup in the closed event handler."
            // Schedule the open after the current input/event processing has finished.
            Dispatcher.BeginInvoke((Action)(() =>
            {
                try
                {
                    if (!ComboBoxHelpers.IsSuppressingEnsureDropDownOpen(combo) && !combo.IsDropDownOpen)
                        combo.IsDropDownOpen = true;
                }
                catch (InvalidOperationException)
                {
                    // Reopening a popup in its Closed handler is not allowed; ignore.
                }
            }), System.Windows.Threading.DispatcherPriority.ApplicationIdle);
        }

        // Try to locate an employee matching typed text (code/name/display)
        private bool TryMatchEmployeeByText(string typed, out EmployeeLookupDto? match)
        {
            match = null;
            if (string.IsNullOrWhiteSpace(typed)) return false;

            // Delegate matching to the reusable helper which inspects configured member paths / ToString
            if (ComboBoxHelpers.TryMatchByText(cmbEmployeeIdNo, typed, out var obj) && obj is EmployeeLookupDto dto)
            {
                match = dto;
                return true;
            }

            return false;
        }

        // Try to locate a security group matching typed text (code/name/display)
        private bool TryMatchSecurityGroupByText(string typed, out SecurityGroupLookupDto? match)
        {
            match = null;
            if (string.IsNullOrWhiteSpace(typed)) return false;

            // Delegate matching to the reusable helper
            if (ComboBoxHelpers.TryMatchByText(cmbSecurityGroupIdNo, typed, out var obj) && obj is SecurityGroupLookupDto dto)
            {
                match = dto;
                return true;
            }

            return false;
        }
    }
}
