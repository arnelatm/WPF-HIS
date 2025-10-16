using AATM.App.HisWpf.ViewModels;
using AATM.Contracts.Interfaces.Services;
using AATM.Core.Localization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace AATM.App.HisWpf
{
    /// <summary>
    /// Interaction logic for TranslationWindow.xaml
    /// </summary>
    public partial class TranslationWindow : Window
    {
        private TranslationViewModel ViewModel => (TranslationViewModel)DataContext;

        private ILocalizationService _localizationService;
        private string _moduleName = "TranslationWindow"; // module name for lookups

        public TranslationWindow(TranslationViewModel vm, ILocalizationService localizationService)
        {
            InitializeComponent();
            DataContext = vm;
            _localizationService = localizationService;

            btnFirst.Click += BtnFirst_Click;
            btnPrev.Click += BtnPrev_Click;
            btnNext.Click += BtnNext_Click;
            btnLast.Click += BtnLast_Click;
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            btnFind.Click += BtnFind_Click;
            btnSwitchLanguage.Click += BtnSwitchLanguage_Click;

            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            UpdateRecordIndicators();
        }

        private void BtnSwitchLanguage_Click(object sender, RoutedEventArgs e)
        {
            // Switch to Arabic (ar-SA). If already Arabic, switch back to English.
            var newLang = _localizationService.IsRightToLeft ? "en-US" : "ar-SA";
            _localizationService.SetLanguage(newLang, _moduleName);

            // Apply culture and RTL at window level
            this.Language = XmlLanguage.GetLanguage(newLang);
            this.FlowDirection = _localizationService.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;

            // Only localize window chrome (labels/buttons outside the DataGrid)
            LocalizeWindowChrome();

            // Translate DataGrid column headers only (do not touch DataGrid internals)
            foreach (var col in dataGrid.Columns)
            {
                if (col.Header is string s && !string.IsNullOrWhiteSpace(s))
                {
                    col.Header = _localizationService.GetString(_moduleName, s, s);
                }
            }

            // If your grid data is language-dependent, reload it
            // ViewModel.RefreshCommand?.Execute(null);

            // Ensure DataGrid refreshes visuals after header/culture changes
            CollectionViewSource.GetDefaultView(dataGrid.ItemsSource)?.Refresh();
            dataGrid.Items.Refresh();
            dataGrid.UpdateLayout();
        }

        private void LocalizeWindowChrome()
        {
            // Localize the window title
            if (!string.IsNullOrWhiteSpace(this.Title))
                this.Title = _localizationService.GetString(_moduleName, "Title", this.Title);

            static bool IsGlyph(string s)
                => !string.IsNullOrWhiteSpace(s)
                   && s.Length <= 3
                   && s.All(ch => char.IsPunctuation(ch) || char.IsSymbol(ch));

            if (this.Content is not Grid root) return;

            foreach (var child in root.Children)
            {
                // Top buttons row
                if (child is StackPanel sp)
                {
                    foreach (var btnObj in sp.Children.OfType<Button>())
                    {
                        if (btnObj.Content is string content && !IsGlyph(content))
                        {
                            var key = string.IsNullOrWhiteSpace(btnObj.Name) ? content : btnObj.Name;
                            btnObj.Content = _localizationService.GetString(_moduleName, key, content);
                        }
                    }
                    continue;
                }

                // Form labels (outside the grid)
                if (child is Label lbl && lbl.Content is string c && !IsGlyph(c))
                {
                    var key = string.IsNullOrWhiteSpace(lbl.Name) ? c : lbl.Name;
                    lbl.Content = _localizationService.GetString(_moduleName, key, c);
                }

                // Do not process DataGrid subtree or any other templated controls
                // The grid is handled by headers loop above
            }
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

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            bool canExecute = ViewModel.SaveCommand.CanExecute(null);
            if (canExecute)
            {
                ViewModel.SaveCommand.Execute(null);
            }
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
