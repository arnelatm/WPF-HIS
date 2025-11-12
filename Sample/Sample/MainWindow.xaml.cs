using System.Windows;

namespace AATM.Sample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // Check if selection is empty
            if (sqlCombo.SelectedId == null || string.IsNullOrWhiteSpace(sqlCombo.SelectedId?.ToString()))
            {
                sqlCombo.SetError("Selection is required.");
                return;
            }

            sqlCombo.ClearError();
            MessageBox.Show("Saved successfully!", "Info");
        }
    }
}