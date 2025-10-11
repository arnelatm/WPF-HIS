using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AATM.Wpf.App.HIS.Forms;

namespace AATM.Wpf.App.HIS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Mitigate SqlClient native SNI load issues on Windows by forcing managed networking
            TryEnableManagedSqlClientNetworking();
        }

        private static void TryEnableManagedSqlClientNetworking()
        {
            try
            {
                // Microsoft.Data.SqlClient (primary switch)
                AppContext.SetSwitch("Switch.Microsoft.Data.SqlClient.UseManagedNetworkingOnWindows", true);
                // System.Data.SqlClient (no-op on some versions, safe to set)
                AppContext.SetSwitch("System.Data.SqlClient.UseManagedNetworkingOnWindows", true);
            }
            catch
            {
                // Intentionally ignore: switch setting failures should not crash the app
            }
        }

        private void OpenTranslationManager_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var sp = (Application.Current as App)?.Services;
                var win = sp != null
                    ? Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions
                        .GetService<AATM.Wpf.App.HIS.Forms.TranslationWindow>(sp)
                        ?? new AATM.Wpf.App.HIS.Forms.TranslationWindow()
                    : new AATM.Wpf.App.HIS.Forms.TranslationWindow();

                win.Owner = this;

                // If your window expects a ViewModel and does not set it internally,
                // uncomment and supply the required dependencies:
                // win.DataContext = new TranslationViewModel(/* services, repo, etc. */);

                win.Show(); // or win.ShowDialog();
            }
            catch (TypeInitializationException ex) when (IsSqlClientInitError(ex))
            {
                MessageBox.Show(
                    this,
                    "Failed to initialize SQL Client. This is commonly caused by missing native SNI components or incompatible SqlClient versions. " +
                    "Managed networking has been enabled, but the error still occurred.\n\nDetails:\n" + ex,
                    "SQL Client Initialization Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    this,
                    "Failed to open Translation Manager.\n\nDetails:\n" + ex,
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private static bool IsSqlClientInitError(Exception ex)
        {
            var text = ex.ToString();
            return text.Contains("SqlClient", StringComparison.OrdinalIgnoreCase)
                   || text.Contains("TdsParser", StringComparison.OrdinalIgnoreCase)
                   || text.Contains("SNILoadHandle", StringComparison.OrdinalIgnoreCase);
        }
    }
}