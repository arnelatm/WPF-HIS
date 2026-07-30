using AATM.App.HisWpf.Helpers;
using AATM.App.HisWpf.ViewModels;
using AATM.Contracts.Dtos;
using AATM.Contracts.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;

namespace AATM.App.HisWpf
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private readonly UserViewModel _viewModel;

        // configurable debounce in milliseconds (kept for XAML binding)
        private int _filterDebounceMs = 120; // default shorter debounce

        private ILocalizationService _localization_service;
        private readonly string _moduleName = "UserWindow";

        // UI cache for localization
        private bool _originalsCached;
        private string _originalTitle = string.Empty;
        private readonly Dictionary<DataGridColumn, string> _originalColumnHeaders = new();

        private string? _currentFilter;

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

            // Wire buttons
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

            // Note:
            // Per-combo edit-mode filtering is now handled by the attached FilteredComboBoxBehavior
            // Top-level combo boxes are configured in XAML to use the behavior; remove code-behind
            // handlers to avoid focus-stealing or duplicate behavior.
        }

        private UserViewModel ViewModel => (UserViewModel)DataContext;

        // ---------- Other UI handlers ----------

        // ---------- Localization and UI chrome ----------
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

        private void ApplyFilter(string? term)
        {
            DataGridFilterHelper.ApplyTextFilter(dataGrid, term);
        }

        private void BtnSwitchLanguage_Click(object sender, RoutedEventArgs e)
        {
            // decide requested culture
            var requested = _localization_service.IsRightToLeft ? "en-US" : "ar-SA";
            var culture = requested;

            try
            {
                // Validate the culture string before using it (will throw CultureNotFoundException if invalid)
                var ci = CultureInfo.GetCultureInfo(culture);

                // Ask service to set language (may itself throw)
                _localization_service.SetLanguage(ci.Name, _moduleName);

                // Apply to WPF window
                this.Language = XmlLanguage.GetLanguage(ci.Name);
                this.FlowDirection = ci.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
            }
            catch (CultureNotFoundException)
            {
                MessageBox.Show($"Requested language '{culture}' is not available. Falling back to 'en-US'.", "Localization", MessageBoxButton.OK, MessageBoxImage.Warning);

                // Fallback to en-US
                culture = "en-US";
                try
                {
                    var fallback = CultureInfo.GetCultureInfo(culture);
                    _localization_service.SetLanguage(fallback.Name, _moduleName);
                    this.Language = XmlLanguage.GetLanguage(fallback.Name);
                    this.FlowDirection = fallback.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
                }
                catch { /* swallow fallback failures - non-fatal for UI */ }
            }
            catch { /* swallow localization errors - non-fatal for UI */ }

            // Update UI chrome / headers using the (possibly fallback) culture state
            try
            {
                CacheOriginalWindowChrome();
                CacheOriginalColumnHeaders();

                LocalizeWindowChrome(culture);

                foreach (var col in dataGrid.Columns)
                {
                    if (!_originalColumnHeaders.TryGetValue(col, out var original) || string.IsNullOrWhiteSpace(original))
                        continue;

                    col.Header = IsEnglish(culture) ? original : _localization_service.GetString(_moduleName, original, original);
                }

                CollectionViewSource.GetDefaultView(dataGrid.ItemsSource)?.Refresh();
                dataGrid.Items.Refresh();
                dataGrid.UpdateLayout();
            }
            catch { /* ignore UI update failures */ }
        }

        private static bool IsEnglish(string lang) => lang.StartsWith("en", StringComparison.OrdinalIgnoreCase);
        private static bool IsGlyph(string s) => !string.IsNullOrWhiteSpace(s) && s.Length <= 3 && s.All(ch => char.IsPunctuation(ch) || char.IsSymbol(ch));

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
                                btn.Tag = content;
                        }
                        continue;
                    }

                    if (child is Label lbl && lbl.Content is string c && !IsGlyph(c) && lbl.Tag is null)
                        lbl.Tag = c;
                }
            }
            _originalsCached = true;
        }

        private void CacheOriginalColumnHeaders()
        {
            foreach (var col in dataGrid.Columns)
            {
                if (_originalColumnHeaders.ContainsKey(col)) continue;
                if (col.Header is string s && !string.IsNullOrWhiteSpace(s)) _originalColumnHeaders[col] = s;
            }
        }

        private void LocalizeWindowChrome(string lang)
        {
            if (!string.IsNullOrWhiteSpace(_originalTitle))
                this.Title = IsEnglish(lang) ? _originalTitle : _localization_service.GetString(_moduleName, "Title", _originalTitle);

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
                        btn.Content = IsEnglish(lang) ? original : _localization_service.GetString(_moduleName, string.IsNullOrWhiteSpace(btn.Name) ? original : btn.Name, original);
                    }
                    continue;
                }
                if (child is Label lbl && lbl.Content is string c && !IsGlyph(c))
                {
                    var original = lbl.Tag as string ?? c;
                    if (lbl.Tag is null) lbl.Tag = original;
                    lbl.Content = IsEnglish(lang) ? original : _localization_service.GetString(_moduleName, string.IsNullOrWhiteSpace(lbl.Name) ? original : lbl.Name, original);
                }
            }
        }

        private void BtnFirst_Click(object sender, RoutedEventArgs e) { if (ViewModel.Users.Count > 0) ViewModel.SelectedUser = ViewModel.Users[0]; }
        private void BtnPrev_Click(object sender, RoutedEventArgs e) { var idx = ViewModel.Users.IndexOf(ViewModel.SelectedUser); if (idx > 0) ViewModel.SelectedUser = ViewModel.Users[idx - 1]; }
        private void BtnNext_Click(object sender, RoutedEventArgs e) { var idx = ViewModel.Users.IndexOf(ViewModel.SelectedUser); if (idx < ViewModel.Users.Count - 1) ViewModel.SelectedUser = ViewModel.Users[idx + 1]; }
        private void BtnLast_Click(object sender, RoutedEventArgs e) { if (ViewModel.Users.Count > 0) ViewModel.SelectedUser = ViewModel.Users[ViewModel.Users.Count - 1]; }
        private void BtnSave_Click(object sender, RoutedEventArgs e) { if (ViewModel.SaveCommand.CanExecute(null)) ViewModel.SaveCommand.Execute(null); }
        private void BtnDelete_Click(object sender, RoutedEventArgs e) { if (ViewModel.DeleteCommand.CanExecute(null)) ViewModel.DeleteCommand.Execute(null); }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ViewModel.SelectedUser))
            {
                if (ViewModel.SelectedUser != null)
                {
                    dataGrid.SelectedItem = ViewModel.SelectedUser;
                    dataGrid.ScrollIntoView(ViewModel.SelectedUser);
                }
                UpdateRecordIndicators();
            }
            if (e.PropertyName == nameof(ViewModel.Users)) UpdateRecordIndicators();
        }

        private void UpdateRecordIndicators()
        {
            var idx = ViewModel.Users.IndexOf(ViewModel.SelectedUser);
            txtCurrentRecord.Text = (idx >= 0 ? (idx + 1).ToString() : "0");
            txtRecordCount.Text = ViewModel.Users.Count.ToString();
        }

        // Add this constructor to allow the XAML designer to instantiate the window
        // and to set up runtime-only handlers guarded by design-mode checks.
        public UserWindow()
        {
            // Only initialize the visual tree. Avoid running DI or runtime-only logic here.
            InitializeComponent();
            // Runtime-only wiring: guard so the XAML designer won't execute these.
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                // Attach DataGrid edit hooks to disable/reenable top combobox behaviors
                dataGrid.BeginningEdit += DataGrid_BeginningEdit;
                dataGrid.CellEditEnding += DataGrid_CellEditEnding;
                dataGrid.LostFocus += DataGrid_LostFocus;
            }
        }

        private void DataGrid_BeginningEdit(object? sender, DataGridBeginningEditEventArgs e)
        {
            // Temporarily disable top combobox filtering behavior so nothing in background can open/pop or steal focus.
            SetTopFilteredBehaviorEnabled(false);
        }

        private void DataGrid_CellEditEnding(object? sender, DataGridCellEditEndingEventArgs e)
        {
            // Re-enable after edit finishes. Use Dispatcher to ensure edit completion first.
            Dispatcher.BeginInvoke(new Action(() => SetTopFilteredBehaviorEnabled(true)));
        }

        private void DataGrid_LostFocus(object? sender, RoutedEventArgs e)
        {
            // Safety: re-enable if something went wrong
            SetTopFilteredBehaviorEnabled(true);
        }

        private void SetTopFilteredBehaviorEnabled(bool enabled)
        {
            // Names match XAML: cmbEmployeeIdNo and cmbSecurityGroupIdNo
            // Use the behavior type from the shared controls assembly (fully-qualified to avoid ambiguity)
            var prop = AATM.UI.Controls.FilteredComboBoxBehavior.IsEnabledProperty;
            cmbEmployeeIdNo.SetValue(prop, enabled);
            cmbSecurityGroupIdNo.SetValue(prop, enabled);
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

            try
            {
                dataGrid.BeginningEdit -= DataGrid_BeginningEdit;
                dataGrid.CellEditEnding -= DataGrid_CellEditEnding;
                dataGrid.LostFocus -= DataGrid_LostFocus;
            }
            catch { }

            base.OnClosed(e);
        }

        // Allow runtime configuration of debounce
        public int FilterDebounceMilliseconds
        {
            get => _filterDebounceMs;
            set { _filterDebounceMs = Math.Max(25, value); } // lower bound
        }
    }
}