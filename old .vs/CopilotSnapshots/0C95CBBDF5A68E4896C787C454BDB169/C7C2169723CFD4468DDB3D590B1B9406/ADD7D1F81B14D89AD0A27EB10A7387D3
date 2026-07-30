using AATM.App.HisWpf.ViewModels;
using AATM.Contracts.Interfaces.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;
using AATM.Contracts.Dtos;
using System.Linq;
using AATM.App.HisWpf.Helpers;

namespace AATM.App.HisWpf
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private readonly UserViewModel _viewModel;

        // Prefer resolving via DI; this overload chains to the primary ctor
        public UserWindow(UserViewModel viewmodel)
            : this(vm: viewmodel, localizationService: App.Host.Services.GetRequiredService<ILocalizationService>())
        {
        }

        // Primary constructor used by DI
        public UserWindow(UserViewModel vm, ILocalizationService localizationService)
        {
            InitializeComponent();

            _viewModel = vm;
            // Ensure initialization always runs regardless of which ctor is used
            Loaded += async (_, __) =>
            {
                await _viewModel.InitializeAsync();
            };

            _localization_service = localizationService;
            DataContext = vm;

            btnFirst.Click += BtnFirst_Click;
            btnPrev.Click += BtnPrev_Click;
            btnNext.Click += BtnNext_Click;
            btnLast.Click += BtnLast_Click;
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            btnFind.Click += BtnFind_Click;
            btnResetFilter.Click += BtnResetFilter_Click;
            btnSwitchLanguage.Click += BtnSwitchLanguage_Click;

            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            UpdateRecordIndicators();

            // Note: removed custom ComboBoxManager attachments and filtering helpers to restore default ComboBox behavior.
        }

        private UserViewModel ViewModel => (UserViewModel)DataContext;

        private ILocalizationService _localization_service;
        private readonly string _moduleName = "UserWindow";

        // NEW: originals cache
        private bool _originalsCached;
        private string _originalTitle = string.Empty;
        private readonly Dictionary<DataGridColumn, string> _originalColumnHeaders = new();

        // NEW: current filter text
        private string? _currentFilter;

        private void BtnFind_Click(object sender, RoutedEventArgs e)
        {
            var input = Microsoft.VisualBasic.Interaction.InputBox("Enter text to filter:", "Filter Users");
            if (string.IsNullOrWhiteSpace(input))
                return;

            _currentFilter = input.Trim();
            ApplyFilter(_currentFilter);
        }

        private void BtnResetFilter_Click(object sender, RoutedEventArgs e)
        {
            _currentFilter = null;
            ApplyFilter(null);
        }

        // Minimal forwarder to centralized filtering helper
        private void ApplyFilter(string? term)
        {
            DataGridFilterHelper.ApplyTextFilter(dataGrid, term);
        }

        private void BtnSwitchLanguage_Click(object sender, RoutedEventArgs e)
        {
            // Switch to Arabic (ar-SA). If already Arabic, switch back to English.
            var newLang = _localization_service.IsRightToLeft ? "en-US" : "ar-SA";
            _localization_service.SetLanguage(newLang, _moduleName);

            // Apply culture and RTL at window level
            this.Language = XmlLanguage.GetLanguage(newLang);
            this.FlowDirection = _localization_service.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;

            // Cache originals once
            CacheOriginalWindowChrome();
            CacheOriginalColumnHeaders();

            // Localize chrome using cached originals
            LocalizeWindowChrome(newLang);

            // Translate DataGrid column headers using cached originals
            foreach (var col in dataGrid.Columns)
            {
                if (!_originalColumnHeaders.TryGetValue(col, out var original) || string.IsNullOrWhiteSpace(original))
                    continue;

                if (IsEnglish(newLang))
                    col.Header = original;
                else
                    col.Header = _localization_service.GetString(_moduleName, original, original);
            }

            // Ensure DataGrid refreshes visuals after header/culture changes
            CollectionViewSource.GetDefaultView(dataGrid.ItemsSource)?.Refresh();
            dataGrid.Items.Refresh();
            dataGrid.UpdateLayout();
        }

        private static bool IsEnglish(string lang)
            => lang.StartsWith("en", StringComparison.OrdinalIgnoreCase);

        private static bool IsGlyph(string s)
            => !string.IsNullOrWhiteSpace(s)
               && s.Length <= 3
               && s.All(ch => char.IsPunctuation(ch) || char.IsSymbol(ch));

        // Cache originals for window title, labels, and buttons (outside the grid)
        private void CacheOriginalWindowChrome()
        {
            if (_originalsCached) return;
            _originalTitle = this.Title ?? string.Empty;

            if (this.Content is Grid root)
            {
                foreach (var child in root.Children)
                {
                    if (child is StackPanel sp)
                    {
                        foreach (var btn in sp.Children.OfType<Button>())
                        {
                            if (btn.Content is string content && !IsGlyph(content) && btn.Tag is null)
                            {
                                btn.Tag = content; // store original in Tag
                            }
                        }
                        continue;
                    }

                    if (child is Label lbl && lbl.Content is string c && !IsGlyph(c) && lbl.Tag is null)
                    {
                        lbl.Tag = c; // store original in Tag
                    }
                }
            }

            _originalsCached = true;
        }

        // Cache original headers for columns once
        private void CacheOriginalColumnHeaders()
        {
            foreach (var col in dataGrid.Columns)
            {
                if (_originalColumnHeaders.ContainsKey(col)) continue;
                if (col.Header is string s && !string.IsNullOrWhiteSpace(s))
                {
                    _originalColumnHeaders[col] = s;
                }
            }
        }

        // Use cached originals to set text for current language
        private void LocalizeWindowChrome(string lang)
        {
            // Title
            if (!string.IsNullOrWhiteSpace(_originalTitle))
            {
                this.Title = IsEnglish(lang)
                    ? _originalTitle
                    : _localization_service.GetString(_moduleName, "Title", _originalTitle);
            }

            if (this.Content is not Grid root) return;

            foreach (var child in root.Children)
            {
                if (child is StackPanel sp)
                {
                    foreach (var btn in sp.Children.OfType<Button>())
                    {
                        if (btn.Content is not string content || IsGlyph(content)) continue;

                        var original = btn.Tag as string ?? content;
                        if (btn.Tag is null) btn.Tag = original;

                        btn.Content = IsEnglish(lang)
                            ? original
                            : _localization_service.GetString(_moduleName, string.IsNullOrWhiteSpace(btn.Name) ? original : btn.Name, original);
                    }
                    continue;
                }

                if (child is Label lbl && lbl.Content is string c && !IsGlyph(c))
                {
                    var original = lbl.Tag as string ?? c;
                    if (lbl.Tag is null) lbl.Tag = original;

                    lbl.Content = IsEnglish(lang)
                        ? original
                        : _localization_service.GetString(_moduleName, string.IsNullOrWhiteSpace(lbl.Name) ? original : lbl.Name, original);
                }
            }
        }

        private void BtnFirst_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.Users.Count > 0)
                ViewModel.SelectedUser = ViewModel.Users[0];
        }

        private void BtnPrev_Click(object sender, RoutedEventArgs e)
        {
            var idx = ViewModel.Users.IndexOf(ViewModel.SelectedUser);
            if (idx > 0)
                ViewModel.SelectedUser = ViewModel.Users[idx - 1];
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            var idx = ViewModel.Users.IndexOf(ViewModel.SelectedUser);
            if (idx < ViewModel.Users.Count - 1)
                ViewModel.SelectedUser = ViewModel.Users[idx + 1];
        }

        private void BtnLast_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.Users.Count > 0)
                ViewModel.SelectedUser = ViewModel.Users[ViewModel.Users.Count - 1];
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

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ViewModel.SelectedUser))
            {
                if (ViewModel.SelectedUser != null)
                {
                    dataGrid.SelectedItem = ViewModel.SelectedUser;
                    dataGrid.ScrollIntoView(ViewModel.SelectedUser);
                }
                UpdateRecordIndicators();

                // Removed synchronization logic that depended on removed filtering/view helpers.
            }
            if (e.PropertyName == nameof(ViewModel.Users))
            {
                UpdateRecordIndicators();
            }
        }

        private void UpdateRecordIndicators()
        {
            var idx = ViewModel.Users.IndexOf(ViewModel.SelectedUser);
            txtCurrentRecord.Text = (idx >= 0 ? (idx + 1).ToString() : "0");
            txtRecordCount.Text = ViewModel.Users.Count.ToString();
        }

        // Add this override to unsubscribe event handlers when the window closes
        protected override void OnClosed(System.EventArgs e)
        {
            // Unsubscribe UI event handlers to avoid leaks
            try { ViewModel.PropertyChanged -= ViewModel_PropertyChanged; } catch { }

            try
            {
                btnFirst.Click -= BtnFirst_Click;
                btnPrev.Click -= BtnPrev_Click;
                btnNext.Click -= BtnNext_Click;
                btnLast.Click -= BtnLast_Click;
                btnSave.Click -= BtnSave_Click;
                btnDelete.Click -= BtnDelete_Click;
                btnFind.Click -= BtnFind_Click;
                btnResetFilter.Click -= BtnResetFilter_Click;
                btnSwitchLanguage.Click -= BtnSwitchLanguage_Click;
            }
            catch { }

            base.OnClosed(e);
        }
    }
}