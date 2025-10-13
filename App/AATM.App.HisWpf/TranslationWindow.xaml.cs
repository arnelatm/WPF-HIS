using AATM.App.HisWpf.ViewModels;
using System.Diagnostics;
using System.Windows;

namespace AATM.App.HisWpf
{
    /// <summary>
    /// Interaction logic for TranslationWindow.xaml
    /// </summary>
    public partial class TranslationWindow : Window
    {
        public TranslationWindow(TranslationViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
            Loaded += (_, __) =>
            {
                Debug.Assert(DataContext != null, "DataContext is null");
                Debug.WriteLine($"VM type: {DataContext.GetType().FullName}");
            };
        }
    }
}