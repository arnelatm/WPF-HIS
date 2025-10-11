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

namespace AATM.Wpf.UI.BaseConrols
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class NavigatorCrudControl : UserControl
    {
        public NavigatorCrudControl()
        {
            InitializeComponent();
        }

        public ICommand FirstCommand
        {
            get => (ICommand)GetValue(FirstCommandProperty);
            set => SetValue(FirstCommandProperty, value);
        }
        public static readonly DependencyProperty FirstCommandProperty =
            DependencyProperty.Register(nameof(FirstCommand), typeof(ICommand), typeof(NavigatorCrudControl));

        public ICommand PreviousCommand
        {
            get => (ICommand)GetValue(PreviousCommandProperty);
            set => SetValue(PreviousCommandProperty, value);
        }
        public static readonly DependencyProperty PreviousCommandProperty =
            DependencyProperty.Register(nameof(PreviousCommand), typeof(ICommand), typeof(NavigatorCrudControl));

        public ICommand NextCommand
        {
            get => (ICommand)GetValue(NextCommandProperty);
            set => SetValue(NextCommandProperty, value);
        }
        public static readonly DependencyProperty NextCommandProperty =
            DependencyProperty.Register(nameof(NextCommand), typeof(ICommand), typeof(NavigatorCrudControl));

        public ICommand LastCommand
        {
            get => (ICommand)GetValue(LastCommandProperty);
            set => SetValue(LastCommandProperty, value);
        }
        public static readonly DependencyProperty LastCommandProperty =
            DependencyProperty.Register(nameof(LastCommand), typeof(ICommand), typeof(NavigatorCrudControl));

        public ICommand AddCommand
        {
            get => (ICommand)GetValue(AddCommandProperty);
            set => SetValue(AddCommandProperty, value);
        }
        public static readonly DependencyProperty AddCommandProperty =
            DependencyProperty.Register(nameof(AddCommand), typeof(ICommand), typeof(NavigatorCrudControl));

        public ICommand DeleteCommand
        {
            get => (ICommand)GetValue(DeleteCommandProperty);
            set => SetValue(DeleteCommandProperty, value);
        }
        public static readonly DependencyProperty DeleteCommandProperty =
            DependencyProperty.Register(nameof(DeleteCommand), typeof(ICommand), typeof(NavigatorCrudControl));

        public ICommand ModifyCommand
        {
            get => (ICommand)GetValue(ModifyCommandProperty);
            set => SetValue(ModifyCommandProperty, value);
        }
        public static readonly DependencyProperty ModifyCommandProperty =
            DependencyProperty.Register(nameof(ModifyCommand), typeof(ICommand), typeof(NavigatorCrudControl));

        public ICommand ClearCommand
        {
            get => (ICommand)GetValue(ClearCommandProperty);
            set => SetValue(ClearCommandProperty, value);
        }
        public static readonly DependencyProperty ClearCommandProperty =
            DependencyProperty.Register(nameof(ClearCommand), typeof(ICommand), typeof(NavigatorCrudControl));

        public ICommand SaveCommand
        {
            get => (ICommand)GetValue(SaveCommandProperty);
            set => SetValue(SaveCommandProperty, value);
        }
        public static readonly DependencyProperty SaveCommandProperty =
            DependencyProperty.Register(nameof(SaveCommand), typeof(ICommand), typeof(NavigatorCrudControl));

        public ICommand UndoCommand
        {
            get => (ICommand)GetValue(UndoCommandProperty);
            set => SetValue(UndoCommandProperty, value);
        }
        public static readonly DependencyProperty UndoCommandProperty =
            DependencyProperty.Register(nameof(UndoCommand), typeof(ICommand), typeof(NavigatorCrudControl));

        public ICommand FindCommand
        {
            get => (ICommand)GetValue(FindCommandProperty);
            set => SetValue(FindCommandProperty, value);
        }
        public static readonly DependencyProperty FindCommandProperty =
            DependencyProperty.Register(nameof(FindCommand), typeof(ICommand), typeof(NavigatorCrudControl));
    }
}
