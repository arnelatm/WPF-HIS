using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace AATM.App.HisWpf
{
    /// <summary>
    /// DataGridTextColumn that applies common validation behavior and styles.
    /// - Uses global styles for display and editing elements.
    /// - Ensures bindings validate via IDataErrorInfo/INotifyDataErrorInfo and update on property changes.
    /// </summary>
    public class ValidatedTextColumn : DataGridTextColumn
    {
        public ValidatedTextColumn()
        {
            // Apply shared styles if present in app resources
            ElementStyle = TryFindStyle("DataGridTextBlockErrorStyle");
            EditingElementStyle = TryFindStyle("DataGridCellErrorStyle");
        }

        protected override void OnBindingChanged(BindingBase oldBinding, BindingBase newBinding)
        {
            base.OnBindingChanged(oldBinding, newBinding);

            if (newBinding is Binding b)
            {
                // Ensure validation flags and real-time updates are enabled
                b.ValidatesOnDataErrors = true;
                b.ValidatesOnNotifyDataErrors = true;
                b.NotifyOnValidationError = true;
                if (b.UpdateSourceTrigger == UpdateSourceTrigger.Default)
                {
                    b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                }
            }
        }

        private static Style? TryFindStyle(object key)
        {
            if (Application.Current != null)
            {
                return Application.Current.TryFindResource(key) as Style;
            }
            return null;
        }
    }
}
