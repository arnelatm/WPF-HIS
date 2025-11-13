using AATM.Modules.Localization;
using AATM.Modules.Users;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Input;

namespace AATM.App.HisWpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void OpenTranslationManager_Click(object sender, RoutedEventArgs e)
        {
            var svc = App.Host.Services.GetRequiredService<TranslationCrudService>();
            //try
            //{
            //    // var rows = await svc.GetAllAsync();
            //    // MessageBox.Show(this, $"DB returned {rows.Count} rows.", "Connectivity", MessageBoxButton.OK);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(this, $"DB call failed:\n{ex}", "Connectivity", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return;
            //}

            var win = App.Host.Services.GetRequiredService<TranslationWindow>();
            win.Owner = this;
            win.Show();
        }

        private void OpenUsersManager_Click(object sender, RoutedEventArgs e)
        {
            var svc = App.Host.Services.GetRequiredService<UserCrudService>();
            //try
            //{
            //    var rows = await svc.GetAllAsync();
            //    // MessageBox.Show(this, $"DB returned {rows.Count} rows.", "Connectivity", MessageBoxButton.OK);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(this, $"DB call failed:\n{ex}", "Connectivity", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return;
            //}

            var win = App.Host.Services.GetRequiredService<UserWindow>();
            win.Owner = this;
            win.Show();
        }

    }
}