using System.Collections;
using System.Globalization;
using System.Windows.Data;

namespace AATM.UI.Controls.Converters
{
    public class IdToDisplayTextMultiConverter : IMultiValueConverter
    {
        /// <summary>
        /// Converts an IdNo and a collection to display text using multi-binding.
        /// </summary>
        /// <param name="values">The values to convert.</param>
        /// <param name="targetType">The target type.</param>
        /// <param name="parameter">The converter parameter.</param>
        /// <param name="culture">The culture info.</param>
        /// <returns>The converted display text.</returns>
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

        /// <summary>
        /// Not implemented. Throws NotImplementedException.
        /// </summary>
        /// <param name="value">The value to convert back.</param>
        /// <param name="targetTypes">The target types.</param>
        /// <param name="parameter">The converter parameter.</param>
        /// <param name="culture">The culture info.</param>
        /// <returns>Not applicable.</returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}