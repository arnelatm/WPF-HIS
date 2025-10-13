using AATM.App.WpfHIS.Views;
using System.Windows;

namespace AATM.App.WpfHIS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenTranslationManager_Click(object sender, RoutedEventArgs e)
        {
            var translationWindow = new TranslationWindow();
            translationWindow.Show();
        }
    }
}