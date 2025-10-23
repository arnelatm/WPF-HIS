using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using AATM.Contracts.Dtos;

namespace AATM.App.HisWpf
{
    public partial class UserWindow
    {
        // Suppress reopening the popup while we are programmatically clearing / refreshing bindings
        private bool _suppressEnsureDropDownOpen;

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

        // Helper to get the ICollectionView for a ComboBox's ItemsSource
        private static System.ComponentModel.ICollectionView? GetComboView(ComboBox combo)
        {
            return CollectionViewSource.GetDefaultView(combo.ItemsSource);
        }

        // Helper to clear a combo's temporary filter and refresh on the UI thread
        private void ClearComboFilterAndRefresh(ComboBox combo, bool clearFilterText = false)
        {
            var view = GetComboView(combo);

            // Mark suppression so any TextChanged/PropertyChanged handlers triggered
            // while we update bindings do not try to reopen the popup.
            _suppressEnsureDropDownOpen = true;

            if (view != null)
            {
                // Perform filter clear + refresh and optional ViewModel text clear asynchronously
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    try
                    {
                        view.Filter = null;
                        view.Refresh();
                    }
                    catch
                    {
                        // swallow refresh/filter exceptions
                    }

                    if (clearFilterText)
                    {
                        if (combo == cmbEmployeeIdNo)
                            ViewModel.EmployeeFilterText = string.Empty;
                        else if (combo == cmbSecurityGroupIdNo)
                            ViewModel.SecurityGroupFilterText = string.Empty;
                    }
                }), System.Windows.Threading.DispatcherPriority.Background)
                .Task.ContinueWith(_ => { _suppressEnsureDropDownOpen = false; }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
            }
            else
            {
                // Ensure clearing filter text is always asynchronous so it doesn't run in the ComboBox Closed handler
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    if (clearFilterText)
                    {
                        if (combo == cmbEmployeeIdNo)
                            ViewModel.EmployeeFilterText = string.Empty;
                        else if (combo == cmbSecurityGroupIdNo)
                            ViewModel.SecurityGroupFilterText = string.Empty;
                    }
                }), System.Windows.Threading.DispatcherPriority.Background)
                .Task.ContinueWith(_ => { _suppressEnsureDropDownOpen = false; }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
            }
        }

        private void EnsureDropDownOpen(ComboBox combo)
        {
            // Don't attempt to reopen if we are suppressing (programmatic update)
            if (_suppressEnsureDropDownOpen)
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
                    if (!_suppressEnsureDropDownOpen && !combo.IsDropDownOpen)
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
            match = ViewModel.AvailableEmployees.FirstOrDefault(em =>
                (!string.IsNullOrEmpty(em.DisplayText) && string.Equals(em.DisplayText, typed, StringComparison.OrdinalIgnoreCase))
                || (!string.IsNullOrEmpty(em.EmployeeCode) && string.Equals(em.EmployeeCode, typed, StringComparison.OrdinalIgnoreCase))
                || (!string.IsNullOrEmpty(em.EmployeeName) && string.Equals(em.EmployeeName, typed, StringComparison.OrdinalIgnoreCase))
            );
            return match != null;
        }

        // Try to locate a security group matching typed text (code/name/display)
        private bool TryMatchSecurityGroupByText(string typed, out SecurityGroupLookupDto? match)
        {
            match = null;
            if (string.IsNullOrWhiteSpace(typed)) return false;
            match = ViewModel.AvailableSecurityGroups.FirstOrDefault(sg =>
                (!string.IsNullOrEmpty(sg.DisplayText) && string.Equals(sg.DisplayText, typed, StringComparison.OrdinalIgnoreCase))
                || (!string.IsNullOrEmpty(sg.SecurityGroupCode) && string.Equals(sg.SecurityGroupCode, typed, StringComparison.OrdinalIgnoreCase))
                || (!string.IsNullOrEmpty(sg.SecurityGroupName) && string.Equals(sg.SecurityGroupName, typed, StringComparison.OrdinalIgnoreCase))
            );
            return match != null;
        }
    }
}
