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
        private bool _stylesApplied;

        // Apply styles lazily when cells are generated (avoids ctor-time resource lookup)
        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            EnsureStylesApplied();
            return base.GenerateElement(cell, dataItem);
        }

        protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            EnsureStylesApplied();
            return base.GenerateEditingElement(cell, dataItem);
        }

        private void EnsureStylesApplied()
        {
            if (_stylesApplied || Application.Current is null) return;

            ElementStyle = TryFindStyle("DataGridTextBlockErrorStyle");
            EditingElementStyle = TryFindStyle("DataGridCellErrorStyle");
            _stylesApplied = true;
        }

        protected override void OnBindingChanged(BindingBase? oldBinding, BindingBase? newBinding)
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
