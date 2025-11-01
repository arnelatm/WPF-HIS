using System.Collections.Generic;
using System.Windows;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // set ItemsSource on the named control smartCombo
            smartCombo.ItemsSource = new List<string>
            {
                "Apple","Apricot","Avocado","Banana","Blueberry","Cherry",
                "Date","Fig","Grape","Kiwi","Lemon","Mango","Orange",
                "Peach","Pear","Pineapple","Raspberry","Strawberry","Watermelon"
            };
        }

        private void SmartCombo_ItemSelected(object sender, string selected)
        {
            MessageBox.Show($"You selected: {selected}", "Selected");
        }
    }
}
