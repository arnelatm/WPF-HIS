using AATM.App.HisWpf.ViewModels;
using Microsoft.Extensions.Configuration;
using System.Windows;

namespace AATM.App.WpfHIS.Views 
{
    /// <summary>
    /// Interaction logic for TranslationWindow.xaml
    /// </summary>
    public partial class TranslationWindow : Window
    {
        public TranslationWindow()
        {
            InitializeComponent();

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            DataContext = new TranslationViewModel(configuration);
        }
    }
}
