using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace AATM.App.HisWpf
{
    /// <summary>
    /// DataGridTextColumn that applies common validation behavior and styles.
    /// </summary>
    public class ValidatedTextColumn : DataGridTextColumn
    {
        public ValidatedTextColumn()
        {
            ElementStyle = TryFindStyle("DataGridTextBlockErrorStyle");
            EditingElementStyle = TryFindStyle("DataGridCellErrorStyle");
        }

        protected override void OnBindingChanged(BindingBase oldBinding, BindingBase newBinding)
        {
            base.OnBindingChanged(oldBinding, newBinding);

            if (newBinding is Binding b)
            {
                b.ValidatesOnDataErrors = true;
                b.ValidatesOnNotifyDataErrors = true;
                b.NotifyOnValidationError = true;
                if (b.UpdateSourceTrigger == UpdateSourceTrigger.Default)
                    b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

                // Ensure null source values are displayed as empty strings
                if (b.TargetNullValue == null)
                    b.TargetNullValue = string.Empty;
            }
        }

        private static Style? TryFindStyle(object key)
            => Application.Current?.TryFindResource(key) as Style;
    }
}
