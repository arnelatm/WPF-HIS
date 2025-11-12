using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace AATM.Sample
{
    public partial class MainWindow : Window
    {
        public List<object> TestItems { get; }

        public MainWindow()
        {
            InitializeComponent();

            // Build local test data
            TestItems = Enumerable.Range(1, 100)
                .Select(i => new { IdNo = i, Code = $"C{i}", Name = $"Name {i}" })
                .Cast<object>()
                .ToList();

            DataContext = this;

            btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // Validate both for demo; prefer testCombo for local test
            if (testCombo.SelectedId == null || string.IsNullOrWhiteSpace(testCombo.SelectedId?.ToString()))
            {
                testCombo.SetError("Selection is required.");
                return;
            }

            testCombo.ClearError();
            MessageBox.Show($"Saved: {testCombo.SelectedCode} - {testCombo.SelectedName}", "Info");
        }
    }
}