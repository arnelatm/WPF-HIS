using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
