using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Data;

namespace AATM.App.HisWpf.Helpers
{
    public static class DataGridFilterHelper
    {
        // Apply a text filter. If propertyNames is empty, the filter searches all public string properties.
        public static void ApplyTextFilter(DataGrid grid, string? term, params string[] propertyNames)
        {
            if (grid == null) return;
            var view = CollectionViewSource.GetDefaultView(grid.ItemsSource);
            if (view == null) return;

            if (string.IsNullOrWhiteSpace(term))
            {
                view.Filter = null;
            }
            else
            {
                var t = term.Trim();
                view.Filter = o =>
                {
                    if (o == null) return false;

                    if (propertyNames != null && propertyNames.Length > 0)
                    {
                        foreach (var prop in propertyNames)
                        {
                            var pi = o.GetType().GetProperty(prop, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                            if (pi?.GetValue(o)?.ToString()?.IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0)
                                return true;
                        }
                    }
                    else
                    {
                        // search all string properties
                        var strProps = o.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                            .Where(p => p.PropertyType == typeof(string));
                        foreach (var p in strProps)
                        {
                            if (p.GetValue(o)?.ToString()?.IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0)
                                return true;
                        }
                    }

                    // fallback: check basic properties commonly used in lookup DTOs (safe dynamic access)
                    try
                    {
                        dynamic d = o;
                        return (d.IdNo?.ToString() ?? string.Empty).IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0
                            || (d.DisplayText ?? string.Empty).IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0;
                    }
                    catch
                    {
                        return false;
                    }
                };
            }

            view.Refresh();

            if (grid.Items.Count > 0)
            {
                var first = grid.Items[0];
                grid.SelectedItem = first;
                grid.ScrollIntoView(first);
            }
        }
    }
}
