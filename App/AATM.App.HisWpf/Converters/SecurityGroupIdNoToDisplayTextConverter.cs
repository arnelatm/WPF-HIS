using AATM.App.HisWpf.ViewModels;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace AATM.App.HisWpf
{
    public class SecurityGroupIdNoToDisplayTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return string.Empty;
            if (!int.TryParse(value.ToString(), out var idNo)) return string.Empty;

            if (parameter is System.Collections.IEnumerable list)
            {
                foreach (var item in list)
                {
                    dynamic d = item;
                    try { if ((int)d.IdNo == idNo) return d.DisplayText ?? string.Empty; }
                    catch { }
                }
            }

            if (Application.Current?.MainWindow?.DataContext is UserViewModel vm)
            {
                var sg = vm.AvailableSecurityGroups?.FirstOrDefault(s => s.IdNo == idNo);
                return sg?.DisplayText ?? string.Empty;
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}