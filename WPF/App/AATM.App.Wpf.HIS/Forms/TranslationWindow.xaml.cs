using AATM.App.Wpf.HIS;
using AATM.App.Wpf.HIS.ViewModels;
using AATM.DataAccess.Sql;
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

namespace AATM.Wpf.App.HIS.Forms
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
        }

        private void NavigatorCrudControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
