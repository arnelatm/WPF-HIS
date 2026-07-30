using System.Collections;
using System.Globalization;
using System.Windows.Data;

namespace AATM.UI.Controls.Converters
{
    public class IdToDisplayTextMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length < 2) return string.Empty;
            var idObj = values[0];
            var list = values[1] as IEnumerable;
            if (idObj == null) return string.Empty;
            if (!int.TryParse(idObj.ToString(), out int idNo)) return string.Empty;

            if (list != null)
            {
                foreach (var item in list)
                {
                    try
                    {
                        // dynamic to avoid creating DTO dependencies in converter
                        dynamic d = item;
                        if ((int)d.IdNo == idNo) return d.DisplayText ?? string.Empty;
                    }
                    catch { /* ignore items that don't match shape */ }
                }
            }

            return string.Empty;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}