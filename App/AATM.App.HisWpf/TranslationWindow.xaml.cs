using AATM.App.HisWpf.ViewModels;
using System.Windows;

namespace AATM.App.HisWpf
{
    /// <summary>
    /// Interaction logic for TranslationWindow.xaml
    /// </summary>
    public partial class TranslationWindow : Window
    {

        private TranslationViewModel ViewModel => (TranslationViewModel)DataContext;

        public TranslationWindow(TranslationViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;

            btnFirst.Click += BtnFirst_Click;
            btnPrev.Click += BtnPrev_Click;
            btnNext.Click += BtnNext_Click;
            btnLast.Click += BtnLast_Click;
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            btnFind.Click += BtnFind_Click;

            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            UpdateRecordIndicators();
        }

        private void BtnFirst_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.Translations.Count > 0)
                ViewModel.SelectedTranslation = ViewModel.Translations[0];
        }

        private void BtnPrev_Click(object sender, RoutedEventArgs e)
        {
            var idx = ViewModel.Translations.IndexOf(ViewModel.SelectedTranslation);
            if (idx > 0)
                ViewModel.SelectedTranslation = ViewModel.Translations[idx - 1];
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            var idx = ViewModel.Translations.IndexOf(ViewModel.SelectedTranslation);
            if (idx < ViewModel.Translations.Count - 1)
                ViewModel.SelectedTranslation = ViewModel.Translations[idx + 1];
        }

        private void BtnLast_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.Translations.Count > 0)
                ViewModel.SelectedTranslation = ViewModel.Translations[ViewModel.Translations.Count - 1];
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SaveCommand.CanExecute(null))
                ViewModel.SaveCommand.Execute(null);
        }

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.DeleteCommand.CanExecute(null))
                ViewModel.DeleteCommand.Execute(null);
        }

        private void BtnFind_Click(object sender, RoutedEventArgs e)
        {
            // Example: Find by ID (prompt user for ID)
            var input = Microsoft.VisualBasic.Interaction.InputBox("Enter ID to find:", "Find Translation");
            if (int.TryParse(input, out int id))
            {
                var found = ViewModel.Translations.FirstOrDefault(t => t.ID == id);
                if (found != null)
                    ViewModel.SelectedTranslation = found;
                else
                    MessageBox.Show("Record not found.");
            }
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ViewModel.SelectedTranslation))
            {
                // Scroll DataGrid to selected item
                if (ViewModel.SelectedTranslation != null)
                {
                    dataGrid.SelectedItem = ViewModel.SelectedTranslation;
                    dataGrid.ScrollIntoView(ViewModel.SelectedTranslation);
                }
                UpdateRecordIndicators(); // <-- Ensure this is called here
            }
            if (e.PropertyName == nameof(ViewModel.Translations))
            {
                UpdateRecordIndicators();
            }   
        }

        private void UpdateRecordIndicators()
        {
            var idx = ViewModel.Translations.IndexOf(ViewModel.SelectedTranslation);
            txtCurrentRecord.Text = (idx >= 0 ? (idx + 1).ToString() : "0");
            txtRecordCount.Text = ViewModel.Translations.Count.ToString();
        }

    }
}
