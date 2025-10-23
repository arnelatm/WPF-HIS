using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;
using System.Windows.Media;

namespace AATM.App.HisWpf
{
    /// <summary>
    /// Reusable ComboBox helpers implemented as attached properties and static methods.
    /// - Attach FilterText + FilterMemberPaths to enable filtering of the ComboBox's ItemsSource.
    /// - Use ClearFilterAndRefresh to clear filter and optionally clear bound FilterText.
    /// - Use TryMatchByText to locate an item by text using the configured member paths.
    /// - Visual-tree helpers and EnsureDropDownOpen are added so callers don't need per-window duplicates.
    /// </summary>
    public static class ComboBoxHelpers
    {
        // FilterText: two-way bind this to your viewmodel filter text property.
        public static readonly DependencyProperty FilterTextProperty =
            DependencyProperty.RegisterAttached(
                "FilterText",
                typeof(string),
                typeof(ComboBoxHelpers),
                new PropertyMetadata(string.Empty, OnFilterTextChanged));

        public static void SetFilterText(DependencyObject obj, string value) => obj.SetValue(FilterTextProperty, value ?? string.Empty);
        public static string GetFilterText(DependencyObject obj) => (string)obj.GetValue(FilterTextProperty);

        // Comma-separated member/property/field names to check when comparing typed text to an item.
        // Example: "DisplayText,EmployeeCode,EmployeeName"
        public static readonly DependencyProperty FilterMemberPathsProperty =
            DependencyProperty.RegisterAttached(
                "FilterMemberPaths",
                typeof(string),
                typeof(ComboBoxHelpers),
                new PropertyMetadata("DisplayText"));

        public static void SetFilterMemberPaths(DependencyObject obj, string value) => obj.SetValue(FilterMemberPathsProperty, value ?? string.Empty);
        public static string GetFilterMemberPaths(DependencyObject obj) => (string)obj.GetValue(FilterMemberPathsProperty);

        // Private per-ComboBox suppression flag (prevents reopening while programmatic updates happen)
        private static readonly DependencyProperty SuppressEnsureDropDownOpenProperty =
            DependencyProperty.RegisterAttached(
                "SuppressEnsureDropDownOpen",
                typeof(bool),
                typeof(ComboBoxHelpers),
                new PropertyMetadata(false));

        private static void SetSuppressEnsureDropDownOpen(DependencyObject obj, bool value) => obj.SetValue(SuppressEnsureDropDownOpenProperty, value);
        private static bool GetSuppressEnsureDropDownOpen(DependencyObject obj) => (bool)obj.GetValue(SuppressEnsureDropDownOpenProperty);

        // Public accessor so callers can check whether a specific ComboBox is currently suppressed.
        public static bool IsSuppressingEnsureDropDownOpen(ComboBox combo) => combo != null && GetSuppressEnsureDropDownOpen(combo);

        // Called when FilterText changes: update the collection view's Filter accordingly.
        private static void OnFilterTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not ComboBox combo) return;

            var newText = (e.NewValue as string) ?? string.Empty;
            var memberPaths = GetFilterMemberPaths(combo);

            var view = CollectionViewSource.GetDefaultView(combo.ItemsSource);
            if (view == null) return;

            // If filter text is empty, clear filter
            if (string.IsNullOrWhiteSpace(newText))
            {
                // Clear filter safely on UI thread
                combo.Dispatcher.BeginInvoke((Action)(() =>
                {
                    try
                    {
                        view.Filter = null;
                        view.Refresh();
                    }
                    catch
                    {
                        // swallow filter/refresh exceptions
                    }
                }), DispatcherPriority.Background);

                return;
            }

            // Build filter using reflection and configured member names
            var terms = newText.Trim();
            // Split into terms so "john sm" can match items containing both tokens (optional)
            var searchTerms = terms.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(t => t.Trim())
                                   .Where(t => !string.IsNullOrEmpty(t))
                                   .ToArray();

            var memberNames = memberPaths.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                       .Select(s => s.Trim())
                                       .Where(s => !string.IsNullOrEmpty(s))
                                       .ToArray();

            combo.Dispatcher.BeginInvoke((Action)(() =>
            {
                try
                {
                    view.Filter = item =>
                    {
                        if (item == null) return false;

                        // Combine primary textual candidates to check against search terms:
                        // 1) item's ToString()
                        // 2) any configured member/field values
                        var candidates = new List<string>(capacity: 4);

                        var toStringVal = item.ToString();
                        if (!string.IsNullOrEmpty(toStringVal))
                            candidates.Add(toStringVal);

                        foreach (var name in memberNames)
                        {
                            var prop = item.GetType().GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                            if (prop != null)
                            {
                                var val = prop.GetValue(item)?.ToString();
                                if (!string.IsNullOrEmpty(val))
                                    candidates.Add(val);
                                continue;
                            }

                            var field = item.GetType().GetField(name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                            if (field != null)
                            {
                                var val = field.GetValue(item)?.ToString();
                                if (!string.IsNullOrEmpty(val))
                                    candidates.Add(val);
                            }
                        }

                        if (candidates.Count == 0) return false;

                        // For each search term require that at least one candidate contains it (AND across terms).
                        foreach (var term in searchTerms)
                        {
                            var matchedTerm = candidates.Any(c => c != null && c.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0);
                            if (!matchedTerm) return false;
                        }

                        return true;
                    };

                    view.Refresh();
                }
                catch
                {
                    // swallow
                }
            }), DispatcherPriority.Background);
        }

        // Clear filter and refresh. If clearFilterText is true, the attached FilterText is cleared too.
        public static void ClearFilterAndRefresh(ComboBox combo, bool clearFilterText = false)
        {
            if (combo == null) return;

            var view = CollectionViewSource.GetDefaultView(combo.ItemsSource);

            // mark suppression so any handlers don't try to reopen popup
            SetSuppressEnsureDropDownOpen(combo, true);

            if (view != null)
            {
                combo.Dispatcher.BeginInvoke((Action)(() =>
                {
                    try
                    {
                        view.Filter = null;
                        view.Refresh();
                    }
                    catch
                    {
                        // swallow
                    }

                    if (clearFilterText)
                        SetFilterText(combo, string.Empty);
                }), DispatcherPriority.Background)
                .Task.ContinueWith(_ => SetSuppressEnsureDropDownOpen(combo, false), TaskScheduler.FromCurrentSynchronizationContext());
            }
            else
            {
                // ensure clearing filter text is asynchronous
                combo.Dispatcher.BeginInvoke((Action)(() =>
                {
                    if (clearFilterText)
                        SetFilterText(combo, string.Empty);
                }), DispatcherPriority.Background)
                .Task.ContinueWith(_ => SetSuppressEnsureDropDownOpen(combo, false), TaskScheduler.FromCurrentSynchronizationContext());
            }
        }

        // Try to locate an item in the ComboBox.ItemsSource that matches typed text using the configured member paths.
        // Returns the found item or null.
        public static bool TryMatchByText(ComboBox combo, string typed, out object? match)
        {
            match = null;
            if (combo == null || string.IsNullOrWhiteSpace(typed)) return false;

            var items = combo.ItemsSource as IEnumerable;
            if (items == null) return false;

            var memberPaths = GetFilterMemberPaths(combo);
            var memberNames = memberPaths.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                         .Select(s => s.Trim())
                                         .Where(s => !string.IsNullOrEmpty(s))
                                         .ToArray();

            foreach (var obj in items)
            {
                if (obj == null) continue;

                var toStringVal = obj.ToString();
                if (!string.IsNullOrEmpty(toStringVal) && string.Equals(toStringVal, typed, StringComparison.OrdinalIgnoreCase))
                {
                    match = obj;
                    return true;
                }

                foreach (var name in memberNames)
                {
                    var prop = obj.GetType().GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    if (prop != null)
                    {
                        var val = prop.GetValue(obj)?.ToString();
                        if (!string.IsNullOrEmpty(val) && string.Equals(val, typed, StringComparison.OrdinalIgnoreCase))
                        {
                            match = obj;
                            return true;
                        }
                        continue;
                    }

                    var field = obj.GetType().GetField(name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    if (field != null)
                    {
                        var val = field.GetValue(obj)?.ToString();
                        if (!string.IsNullOrEmpty(val) && string.Equals(val, typed, StringComparison.OrdinalIgnoreCase))
                        {
                            match = obj;
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        // ------------------------------
        // Reusable visual-tree helpers
        // ------------------------------

        // Find a visual child of type T in the visual tree (depth-first).
        public static T? FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            if (parent == null) return null;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T typed) return typed;
                var descendant = FindVisualChild<T>(child);
                if (descendant != null) return descendant;
            }
            return null;
        }

        // Find a parent of type T in the visual tree (walks up).
        public static T? FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            if (child == null) return null;
            DependencyObject? parent = VisualTreeHelper.GetParent(child);
            while (parent != null)
            {
                if (parent is T t) return t;
                parent = VisualTreeHelper.GetParent(parent);
            }
            return null;
        }

        // Safe logic to open the ComboBox dropdown. Respects the internal suppression flag and schedules open asynchronously.
        public static void EnsureDropDownOpen(ComboBox combo)
        {
            if (combo == null) return;

            // Don't attempt to reopen if suppressed
            if (IsSuppressingEnsureDropDownOpen(combo)) return;

            // Only open when the user is focused in the control (avoid opening during initialization)
            if (!combo.IsKeyboardFocusWithin && !combo.IsFocused) return;

            if (combo.IsDropDownOpen) return;

            // Opening a popup synchronously while handling its Closed event can throw.
            combo.Dispatcher.BeginInvoke((Action)(() =>
            {
                try
                {
                    if (!IsSuppressingEnsureDropDownOpen(combo) && !combo.IsDropDownOpen)
                        combo.IsDropDownOpen = true;
                }
                catch (InvalidOperationException)
                {
                    // ignore: reopening popup in closed handler not allowed
                }
            }), DispatcherPriority.ApplicationIdle);
        }
    }
}