using System.Windows;
using System.Windows.Controls;

namespace AATM.UI.Controls
{
    public partial class FilteringComboBoxWithProgress : UserControl
    {
        public static readonly DependencyProperty IsBusyProperty =
            DependencyProperty.Register(
                nameof(IsBusy),
                typeof(bool),
                typeof(FilteringComboBoxWithProgress),
                new PropertyMetadata(false));

        public bool IsBusy
        {
            get => (bool)GetValue(IsBusyProperty);
            set => SetValue(IsBusyProperty, value);
        }

        public FilteringComboBoxWithProgress()
        {
            InitializeComponent();
        }
    }
}