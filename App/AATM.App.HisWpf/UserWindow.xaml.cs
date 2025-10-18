using AATM.App.HisWpf.ViewModels;
using AATM.Contracts.Dtos;
using AATM.Contracts.Interfaces.Services;
using AATM.Modules.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace AATM.App.HisWpf
{
    public partial class UserWindow : Window
    {
        private UserViewModel ViewModel => (UserViewModel)DataContext;

        private readonly ILocalizationService _localizationService;
        private readonly string _moduleName = "UserWindow";

        // Originals cache
        private bool _originalsCached;
        private string _originalTitle = string.Empty;
        private readonly Dictionary<DataGridColumn, string> _originalColumnHeaders = new();

        // Current filter (optional)
        private string? _currentFilter;

        public UserWindow(UserViewModel vm, ILocalizationService localizationService)
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
            btnResetFilter.Click += BtnResetFilter_Click;
            btnSwitchLanguage.Click += BtnSwitchLanguage_Click;

            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            UpdateRecordIndicators();
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

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.DeleteCommand.CanExecute(null))
                ViewModel.DeleteCommand.Execute(null);
        }

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
            var view = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);
            if (view == null) return;

            if (string.IsNullOrWhiteSpace(term))
            {
                view.Filter = null;
            }
            else
            {
                var t = term.Trim();
                view.Filter = o =>
                {
                    if (o is null) return false;
                    string GetString(Func<UserDto, object?> sel)
                    {
                        try { var v = sel((UserDto)o); return v?.ToString() ?? string.Empty; }
                        catch { return string.Empty; }
                    }

                    return GetString(x => x.IdNo).IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0
                        || GetString(x => x.UserName).IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0
                        || GetString(x => x.UserCode).IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0
                        || GetString(x => x.FullName).IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0
                        || GetString(x => x.FullNameAra).IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0
                        || GetString(x => x.EmployeeIdNo).IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0
                        || GetString(x => x.SecurityGroupIdNo).IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0
                        || GetString(x => x.SecurityLevel).IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0
                        || GetString(x => x.Active).IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0;
                };
            }

            view.Refresh();

            if (dataGrid.Items.Count > 0)
            {
                var first = dataGrid.Items[0];
                dataGrid.SelectedItem = first;
                dataGrid.ScrollIntoView(first);
            }
        }

        // New: switch language handler
        private void BtnSwitchLanguage_Click(object sender, RoutedEventArgs e)
        {
            var newLang = _localizationService.IsRightToLeft ? "en-US" : "ar-SA";
            _localizationService.SetLanguage(newLang, _moduleName);

            // Apply culture and RTL at window level
            this.Language = XmlLanguage.GetLanguage(newLang);
            this.FlowDirection = _localizationService.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;

            // Optionally, update UI text and DataGrid headers if you have localization logic
            // LocalizeWindowChrome(newLang);
            // UpdateDataGridHeaders(newLang);
        }

        private static bool IsEnglish(string lang)
            => lang.StartsWith("en", StringComparison.OrdinalIgnoreCase);

        private static bool IsGlyph(string s)
            => !string.IsNullOrWhiteSpace(s)
               && s.Length <= 3
               && s.All(ch => char.IsPunctuation(ch) || char.IsSymbol(ch));

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

        private void LocalizeWindowChrome(string lang)
        {
            if (!string.IsNullOrWhiteSpace(_originalTitle))
            {
                this.Title = IsEnglish(lang)
                    ? _originalTitle
                    : _localizationService.GetString(_moduleName, "Title", _originalTitle);
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
                            : _localizationService.GetString(_moduleName, string.IsNullOrWhiteSpace(btn.Name) ? original : btn.Name, original);
                    }
                    continue;
                }

                if (child is Label lbl && lbl.Content is string c && !IsGlyph(c))
                {
                    var original = lbl.Tag as string ?? c;
                    if (lbl.Tag is null) lbl.Tag = original;

                    lbl.Content = IsEnglish(lang)
                        ? original
                        : _localizationService.GetString(_moduleName, string.IsNullOrWhiteSpace(lbl.Name) ? original : lbl.Name, original);
                }
            }
        }

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
    }
}