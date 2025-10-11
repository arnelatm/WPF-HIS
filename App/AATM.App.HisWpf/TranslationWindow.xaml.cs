using AATM.App.HisWpf.ViewModels;
using System.Windows;

namespace AATM.App.HisWpf
{
    /// <summary>
    /// Interaction logic for TranslationWindow.xaml
    /// </summary>
    public partial class TranslationWindow : Window
    {
        public TranslationWindow()
        {
            InitializeComponent();
            DataContext = new TranslationViewModel();
        }
    }
}
