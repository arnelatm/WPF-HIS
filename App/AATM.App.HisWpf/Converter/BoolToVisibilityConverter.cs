using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace AATM.App.HisWpf.Converter
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public bool CollapseWhenFalse { get; set; } = false;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool val = false;
            if (value is bool b) val = b;
            else if (!bool.TryParse(value?.ToString() ?? "false", out val)) val = false;

            return val ? Visibility.Visible : (CollapseWhenFalse ? Visibility.Collapsed : Visibility.Hidden);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}