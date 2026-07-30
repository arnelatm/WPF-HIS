using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Data;

namespace AATM.UI.Controls.Converters
{
    // Helper used by converters to search a collection for IdNo/display text without
    // requiring a compile-time dependency on your ViewModel type.
    internal static class LookupHelper
    {
        public static string? FindDisplayText(IEnumerable? collection, int idNo, string idPropName = "IdNo", string displayPropName = "DisplayText")
        {
            if (collection == null) return null;
            foreach (var item in collection)
            {
                if (item == null) continue;
                try
                {
                    var t = item.GetType();
                    var idProp = t.GetProperty(idPropName, BindingFlags.Public | BindingFlags.Instance);
                    var displayProp = t.GetProperty(displayPropName, BindingFlags.Public | BindingFlags.Instance);
                    if (idProp == null) continue;
                    var idVal = idProp.GetValue(item);
                    if (idVal is int id && id == idNo)
                    {
                        if (displayProp != null)
                        {
                            var d = displayProp.GetValue(item);
                            return d?.ToString() ?? string.Empty;
                        }
                        return string.Empty;
                    }
                }
                catch
                {
                    // ignore per-original behavior: don't break on unexpected item
                }
            }
            return null;
        }

        // Reflection fallback: Look for a property named propName on Application.Current.MainWindow.DataContext
        public static IEnumerable? GetCollectionFromMainVm(string propName)
        {
            try
            {
                var main = Application.Current?.MainWindow;
                var dc = main?.DataContext;
                if (dc == null) return null;
                var prop = dc.GetType().GetProperty(propName, BindingFlags.Public | BindingFlags.Instance);
                return prop?.GetValue(dc) as IEnumerable;
            }
            catch
            {
                return null;
            }
        }
    }

    public class EmployeeIdNoToDisplayTextConverter : IValueConverter
    {
        // parameter optionally may be the collection (IEnumerable) if you update bindings later.
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is int idNo)) return string.Empty;

            // Prefer collection passed via ConverterParameter
            if (parameter is IEnumerable collection)
            {
                var found = LookupHelper.FindDisplayText(collection, idNo);
                if (found != null) return found;
            }

            // Fallback to main VM available employees via reflection (preserves previous behavior)
            var vmCollection = LookupHelper.GetCollectionFromMainVm("AvailableEmployees");
            var result = LookupHelper.FindDisplayText(vmCollection, idNo);
            return result ?? string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotSupportedException();
    }

    public class SecurityGroupIdNoToDisplayTextConverter : IValueConverter
    {
        // parameter optionally may be the collection (IEnumerable)
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is int idNo)) return string.Empty;

            if (parameter is IEnumerable collection)
            {
                var found = LookupHelper.FindDisplayText(collection, idNo);
                if (found != null) return found;
            }

            var vmCollection = LookupHelper.GetCollectionFromMainVm("AvailableSecurityGroups");
            var result = LookupHelper.FindDisplayText(vmCollection, idNo);
            return result ?? string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotSupportedException();
    }

    // IMultiValueConverter variants: accept [id, collection]
    public class EmployeeIdNoToDisplayTextMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length < 1) return string.Empty;
            if (!(values[0] is int idNo)) return string.Empty;

            if (values.Length >= 2 && values[1] is IEnumerable collection)
            {
                var found = LookupHelper.FindDisplayText(collection, idNo);
                if (found != null) return found;
            }

            var vmCollection = LookupHelper.GetCollectionFromMainVm("AvailableEmployees");
            var result = LookupHelper.FindDisplayText(vmCollection, idNo);
            return result ?? string.Empty;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotSupportedException();
    }

    public class SecurityGroupIdNoToDisplayTextMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length < 1) return string.Empty;
            if (!(values[0] is int idNo)) return string.Empty;

            if (values.Length >= 2 && values[1] is IEnumerable collection)
            {
                var found = LookupHelper.FindDisplayText(collection, idNo);
                if (found != null) return found;
            }

            var vmCollection = LookupHelper.GetCollectionFromMainVm("AvailableSecurityGroups");
            var result = LookupHelper.FindDisplayText(vmCollection, idNo);
            return result ?? string.Empty;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotSupportedException();
    }

    public class StringToIntConverter : IValueConverter
    {
        // source -> target: convert string (UserDto.EmployeeIdNo) to int for SelectedValue
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return 0;
            if (value is int i) return i;
            if (value is string s && int.TryParse(s, out var v)) return v;
            return 0;
        }

        // target -> source: convert selected int back to string (UserDto expects string)
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return string.Empty;
            if (value is int i) return i.ToString();
            if (value is string s) return s;
            return string.Empty;
        }
    }
}