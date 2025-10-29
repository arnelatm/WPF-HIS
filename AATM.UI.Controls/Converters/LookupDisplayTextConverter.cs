using System;
using System.Globalization;
using System.Windows.Data;

namespace AATM.UI.Controls.Converters
{
    public sealed class LookupDisplayTextConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null) return string.Empty;
            // Implementation: keep behavior unchanged
            return value.ToString() ?? string.Empty;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}