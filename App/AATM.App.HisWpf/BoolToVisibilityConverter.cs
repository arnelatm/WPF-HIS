using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace AATM.App.HisWpf
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public bool CollapseWhenFalse { get; set; } = false;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isVisible = false;
            if (value is bool b)
                isVisible = b;

            if (isVisible)
                return Visibility.Visible;
            return CollapseWhenFalse ? Visibility.Collapsed : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility v)
                return v == Visibility.Visible;
            return false;
        }
    }
}