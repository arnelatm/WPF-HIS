using AATM.Business.Validation.ValidationRules;
using AATM.Business.Validation.Validators;
using AATM.Contracts.Dtos;
using AATM.Contracts.Interfaces.Services;
using AATM.Core.Localization;
using AATM.DataAccess;
using AATM.Modules.Localization;
using AATM.Modules.Users;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Input;

namespace AATM.App.HisWpf.ViewModels
{
    public partial class UserViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private readonly UserCrudService _service;
        private readonly ILocalizationService _localizationService;
        private readonly IEmployeeRepository _employeeRepo;
        private readonly ISecurityGroupRepository _securityGroupRepo;

        public ObservableCollection<LanguageItem> AvailableLanguages { get; } = new();
        public ObservableCollection<EmployeeLookupDto> AvailableEmployees { get; } = new();
        private readonly CollectionViewSource _employeeViewSource = new();
        public ICollectionView EmployeeView => _employeeViewSource.View;

        public bool SelectedUserImplementsErrorInfo => SelectedUser is INotifyDataErrorInfo;
        public ObservableCollection<SecurityGroupLookupDto> AvailableSecurityGroups { get; } = new();
        private readonly CollectionViewSource _securityViewSource = new();
        public ICollectionView SecurityGroupView => _securityViewSource.View;

        public ObservableCollection<UserDto> Users { get; } = new();

        public void ClearEmployeeSelection()
        {
            if (SelectedUser != null)
            {
                // Block notifications temporarily
                var oldNotify = SelectedUser as INotifyPropertyChanged;
                if (oldNotify != null)
                    oldNotify.PropertyChanged -= SelectedUser_PropertyChanged;

                // Clear ID and display text
                SelectedUser.EmployeeIdNo = 0;
                EmployeeDisplayText = string.Empty;

                // Reattach and notify
                if (oldNotify != null)
                    oldNotify.PropertyChanged += SelectedUser_PropertyChanged;

                // Notify all relevant properties
                OnPropertyChanged(nameof(SelectedUser));
                OnPropertyChanged(nameof(EmployeeDisplayText));
                ValidateAllProperties();
            }
        }

        public void ClearSecurityGroupSelection()
        {
            if (SelectedUser != null)
            {
                // Block notifications temporarily
                var oldNotify = SelectedUser as INotifyPropertyChanged;
                if (oldNotify != null)
                    oldNotify.PropertyChanged -= SelectedUser_PropertyChanged;

                // Clear ID and display text
                SelectedUser.SecurityGroupIdNo = 0;
                SecurityGroupDisplayText = string.Empty;

                // Reattach and notify
                if (oldNotify != null)
                    oldNotify.PropertyChanged += SelectedUser_PropertyChanged;

                // Notify all relevant properties
                OnPropertyChanged(nameof(SelectedUser));
                OnPropertyChanged(nameof(SecurityGroupDisplayText));
                ValidateAllProperties();
            }
        }

        // Add properties to handle ComboBox display text
        private string _employeeDisplayText = string.Empty;
        public string EmployeeDisplayText
        {
            get => _employeeDisplayText;
            set
            {
                if (_employeeDisplayText != value)
                {
                    _employeeDisplayText = value;
                    OnPropertyChanged();

                    // If text is cleared and we're not in the middle of a selection change
                    if (string.IsNullOrEmpty(value) && SelectedUser?.EmployeeIdNo != 0)
                    {
                        ClearEmployeeSelection();
                    }
                }
            }
        }

        private string _securityGroupDisplayText = string.Empty;
        public string SecurityGroupDisplayText
        {
            get => _securityGroupDisplayText;
            set
            {
                if (_securityGroupDisplayText != value)
                {
                    _securityGroupDisplayText = value;
                    OnPropertyChanged();

                    // If text is cleared and we're not in the middle of a selection change
                    if (string.IsNullOrEmpty(value) && SelectedUser?.SecurityGroupIdNo != 0)
                    {
                        ClearSecurityGroupSelection();
                    }
                }
            }
        }

        private UserDto? _selectedUser;
        public UserDto? SelectedUser
        {
            get => _selectedUser;
            set
            {
                if (_selectedUser != value)
                {
                    if (_selectedUser is INotifyPropertyChanged oldNotify)
                        oldNotify.PropertyChanged -= SelectedUser_PropertyChanged;

                    _selectedUser = value;
                    OnPropertyChanged();

                    // Update display text from lookup maps when selection changes
                    if (_selectedUser != null)
                    {
                        if (_employeeMap.TryGetValue(_selectedUser.EmployeeIdNo, out var empText))
                            EmployeeDisplayText = empText;
                        if (_securityMap.TryGetValue(_selectedUser.SecurityGroupIdNo, out var secText))
                            SecurityGroupDisplayText = secText;
                    }
                    else
                    {
                        EmployeeDisplayText = string.Empty;
                        SecurityGroupDisplayText = string.Empty;
                    }

                    if (_selectedUser is INotifyPropertyChanged newNotify)
                    {
                        newNotify.PropertyChanged += SelectedUser_PropertyChanged;
                        // Also handle changes to the specific properties
                        newNotify.PropertyChanged += (s, e) =>
                        {
                            if (e.PropertyName == nameof(UserDto.EmployeeIdNo))
                            {
                                if (_employeeMap.TryGetValue(_selectedUser.EmployeeIdNo, out var text))
                                    EmployeeDisplayText = text;
                            }
                            else if (e.PropertyName == nameof(UserDto.SecurityGroupIdNo))
                            {
                                if (_securityMap.TryGetValue(_selectedUser.SecurityGroupIdNo, out var text))
                                    SecurityGroupDisplayText = text;
                            }
                        };
                    }

                    ValidateAllProperties();
                    if (SaveCommand is AsyncRelayCommand asyncCmd)
                        asyncCmd.RaiseCanExecuteChanged();
                    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs("UserDto"));
                }
            }
        }

        private void SelectedUser_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            ValidateAllProperties();
            if (SaveCommand is AsyncRelayCommand asyncCmd)
                asyncCmd.RaiseCanExecuteChanged();
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(e.PropertyName));
        }

        public string? ErrorText { get; set; }

        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand RefreshCommand { get; }

        private readonly DtoValidator<UserDto> _UserValidator =
            new DtoValidator<UserDto>(UserDtoValidationRules.Validate);

        public UserViewModel(UserCrudService service, ILocalizationService localizationService, IEmployeeRepository employeeRepo, ISecurityGroupRepository securityGroupRepo)
        {
            _service = service;
            _localizationService = localizationService;
            _employeeRepo = employeeRepo;
            _securityGroupRepo = securityGroupRepo;

            var langs = LocalizationHelper.SafeGetLanguages(_localizationService);
            foreach (var (display, code) in langs)
                AvailableLanguages.Add(new LanguageItem(display, code));

            // Initialize CollectionViewSources
            _employeeViewSource.Source = AvailableEmployees;
            _employeeViewSource.Filter += (_, args) => args.Accepted = EmployeeFilterPredicate(args.Item as EmployeeLookupDto);

            _securityViewSource.Source = AvailableSecurityGroups;
            _securityViewSource.Filter += (_, args) => args.Accepted = SecurityGroupFilterPredicate(args.Item as SecurityGroupLookupDto);

            SaveCommand = new AsyncRelayCommand(
                async _ => await Save(),
                _ => SelectedUser != null && !HasErrors
            );
            DeleteCommand = new AsyncRelayCommand(
                async _ => await Delete(),
                _ => SelectedUser != null
            );
            RefreshCommand = new AsyncRelayCommand(
                async _ => await Refresh()
            );

            AvailableEmployees.CollectionChanged += AvailableEmployees_CollectionChanged;
            AvailableSecurityGroups.CollectionChanged += AvailableSecurityGroups_CollectionChanged;

            foreach (var e in AvailableEmployees) AttachEmployeeItemHandlers(e);
            foreach (var s in AvailableSecurityGroups) AttachSecurityItemHandlers(s);
        }

        private bool EmployeeFilterPredicate(EmployeeLookupDto? emp)
        {
            if (emp == null) return false;
            var filter = EmployeeFilterText?.Trim() ?? string.Empty;
            if (string.IsNullOrEmpty(filter)) return true;
            return (!string.IsNullOrEmpty(emp.DisplayText) && emp.DisplayText.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0)
                || (!string.IsNullOrEmpty(emp.EmployeeName) && emp.EmployeeName.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0)
                || (!string.IsNullOrEmpty(emp.EmployeeCode) && emp.EmployeeCode.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private bool SecurityGroupFilterPredicate(SecurityGroupLookupDto? sg)
        {
            if (sg == null) return false;
            var filter = SecurityGroupFilterText?.Trim() ?? string.Empty;
            if (string.IsNullOrEmpty(filter)) return true;
            return (!string.IsNullOrEmpty(sg.DisplayText) && sg.DisplayText.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0)
                || (!string.IsNullOrEmpty(sg.SecurityGroupName) && sg.SecurityGroupName.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0)
                || (!string.IsNullOrEmpty(sg.SecurityGroupCode) && sg.SecurityGroupCode.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        // Employee filter
        private string _employeeFilterText = "";
        public string EmployeeFilterText
        {
            get => _employeeFilterText;
            set
            {
                if (_employeeFilterText == value) return;
                _employeeFilterText = value;
                OnPropertyChanged();
                try { _employeeViewSource.View?.Refresh(); } catch { }
            }
        }

        // Security group filter
        private string _securityGroupFilterText = "";
        public string SecurityGroupFilterText
        {
            get => _securityGroupFilterText;
            set
            {
                if (_securityGroupFilterText != value)
                {
                    _securityGroupFilterText = value;
                    OnPropertyChanged();
                    try { _securityViewSource.View?.Refresh(); } catch { }
                }
            }
        }

        public async Task LoadEmployeesAsync()
        {
            var employees = await _employeeRepo.GetEmployeesLookupAsync().ConfigureAwait(false);
            await App.Current.Dispatcher.InvokeAsync(() =>
            {
                AvailableEmployees.Clear();
                foreach (var e in employees) AvailableEmployees.Add(e);
                _employeeViewSource.View?.Refresh();

                // rebuild lookup map and notify consumers
                BuildLookupMaps();
                OnPropertyChanged(nameof(EmployeeMap));
            });
        }

        public async Task LoadSecurityGroupsAsync()
        {
            var securityGroups = await _security_group_repo_safe().ConfigureAwait(false);
            await App.Current.Dispatcher.InvokeAsync(() =>
            {
                AvailableSecurityGroups.Clear();
                foreach (var sg in securityGroups) AvailableSecurityGroups.Add(sg);
                _securityViewSource.View?.Refresh();

                // rebuild lookup map and notify consumers
                BuildLookupMaps();
                OnPropertyChanged(nameof(SecurityMap));
            });
        }

        // Helper to call repo safely (keeps code compact)
        private async Task<IEnumerable<SecurityGroupLookupDto>> _security_group_repo_safe()
        {
            try
            {
                var list = await _securityGroupRepo.GetSecurityGroupsLookupAsync().ConfigureAwait(false);
                return list ?? Enumerable.Empty<SecurityGroupLookupDto>();
            }
            catch
            {
                return Enumerable.Empty<SecurityGroupLookupDto>();
            }
        }

        public bool IsBusy { get; set; }
        // Serialize loads and avoid duplicates
        private async Task Refresh(bool reload = false)
        {
            await _loadLock.WaitAsync();
            try
            {
                IsBusy = true;
                OnPropertyChanged(nameof(IsBusy));

                if (reload)
                {
                    Users.Clear();
                    var items = await _service.GetAllAsync().ConfigureAwait(true);
                    foreach (var item in items)
                        Users.Add(item);
                }

                SelectedUser = Users.Count > 0 ? Users[0] : null;
                ErrorText = $"Loaded {Users.Count} User(s).";
            }
            catch (Exception ex)
            {
                ErrorText = $"Load failed: {ex.Message}";
            }
            finally
            {
                IsBusy = false;
                OnPropertyChanged(nameof(IsBusy));
                _loadLock.Release();
            }
            OnPropertyChanged(nameof(ErrorText));
        }

        private async Task Save()
        {
            ValidateAllProperties(); // Ensure errors are up-to-date
            if (HasErrors)
            {
                ErrorText = "Please fix validation errors before saving.";
                OnPropertyChanged(nameof(ErrorText));
                return;
            }
            if (SelectedUser == null) return;
            var saved = await _service.UpsertAsync(SelectedUser);
            ErrorText = saved != null ? "" : "Save failed";
            await Refresh();
        }

        private async Task Delete()
        {
            if (SelectedUser == null) return;
            var ok = await _service.DeleteAsync(SelectedUser.IdNo);
            ErrorText = ok ? "" : "Delete failed";
            await Refresh();
        }

        // Validation logic
        private readonly Dictionary<string, List<string>> _errors = new();

        public bool HasErrors => _errors.Count > 0;
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        private void ValidateProperty(string propertyName, object? value)
        {
            var errors = new List<string>();

            if (propertyName == nameof(UserDto.UserName))
            {
                var str = value switch
                {
                    null => string.Empty,
                    string s => s,
                    _ => Convert.ToString(value) ?? string.Empty
                };

                if (string.IsNullOrWhiteSpace(str))
                    errors.Add("User Name is required.");
            }
            else if (propertyName == nameof(UserDto.SecurityGroupIdNo))
            {
                // Accept int or string convertible to int, treat 0 as missing
                var valid = false;
                if (value is int i) valid = i != 0;
                else if (value != null && int.TryParse(Convert.ToString(value), out var parsed)) valid = parsed != 0;

                if (!valid)
                    errors.Add("Security Group ID is required.");
            }
            else if (propertyName == nameof(UserDto.EmployeeIdNo))
            {
                var valid = false;
                if (value is int i) valid = i != 0;
                else if (value != null && int.TryParse(Convert.ToString(value), out var parsed)) valid = parsed != 0;

                if (!valid)
                    errors.Add("Employee ID Number is required.");
            }

            if (errors.Count > 0)
                _errors[propertyName] = errors;
            else
                _errors.Remove(propertyName);

            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private void ValidateAllProperties()
        {
            _errors.Clear();
            ErrorText = ""; // Clear previous error
            if (SelectedUser != null)
            {
                var errors = _UserValidator.Validate(SelectedUser);
                if (errors.Any())
                {
                    _errors["UserDto"] = errors;
                    ErrorText = string.Join(Environment.NewLine, errors); // <-- Set error text here
                }
                else
                {
                    _errors.Remove("UserDto");
                }
            }
            if (SaveCommand is AsyncRelayCommand asyncCmd)
                asyncCmd.RaiseCanExecuteChanged();
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs("UserDto"));
            OnPropertyChanged(nameof(ErrorText)); // <-- Notify UI of change
        }

        // Make InitializeAsync idempotent
        public async Task InitializeAsync()
        {
            if (Interlocked.Exchange(ref _initOnce, 1) == 1)
                return; // already initialized

            // Start loading lookup data and wait for them to complete first
            await LoadEmployeesSafeAsync();
            await LoadSecurityGroupsSafeAsync();

            // Now load users (depends on lookups to be available for correct display)
            await RefreshSafeAsync();
        }

        private async Task LoadEmployeesSafeAsync()
        {
            try { await LoadEmployeesAsync().ConfigureAwait(false); }
            catch (Exception ex)
            {
                ErrorText = $"Employees load failed: {ex.Message}";
                OnPropertyChanged(nameof(ErrorText));
            }
        }

        private async Task LoadSecurityGroupsSafeAsync()
        {
            try { await LoadSecurityGroupsAsync().ConfigureAwait(false); }
            catch (Exception ex)
            {
                ErrorText = $"Security groups load failed: {ex.Message}";
                OnPropertyChanged(nameof(ErrorText));
            }
        }

        private async Task RefreshSafeAsync()
        {
            try
            {
                await Refresh(true).ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                ErrorText = $"Users load failed: {ex.Message}";
                OnPropertyChanged(nameof(ErrorText));
            }
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        System.Collections.IEnumerable INotifyDataErrorInfo.GetErrors(string? propertyName)
        {
            // Return errors for the specified property, or all errors if propertyName is null or empty
            if (string.IsNullOrEmpty(propertyName))
            {
                // Flatten all errors into a single list
                return _errors.Values.SelectMany(e => e).ToList();
            }
            return _errors.TryGetValue(propertyName, out var errors) ? errors : Enumerable.Empty<string>();
        }

        private int _initOnce; // 0 = not started, 1 = started
        private readonly SemaphoreSlim _loadLock = new(1, 1);

        // add members
        private Dictionary<int, string> _employeeMap = new();
        public IReadOnlyDictionary<int, string> EmployeeMap => _employeeMap;
        private Dictionary<int, string> _securityMap = new();
        public IReadOnlyDictionary<int, string> SecurityMap => _security_map_safe();

        // populate after loading lists
        private void BuildLookupMaps()
        {
            _employeeMap = AvailableEmployees
                .Where(e => e != null)
                .ToDictionary(e => e.IdNo, e => e.DisplayText ?? string.Empty);

            _securityMap = AvailableSecurityGroups
                .Where(s => s != null)
                .ToDictionary(s => s.IdNo, s => s.DisplayText ?? string.Empty);
        }

        private IReadOnlyDictionary<int, string> _security_map_safe()
        {
            return _securityMap;
        }

        private void AvailableEmployees_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems != null)
                    {
                        foreach (EmployeeLookupDto? item in e.NewItems.OfType<EmployeeLookupDto>())
                            if (item != null)
                                AttachEmployeeItemHandlers(item);
                        BuildLookupMaps();
                        OnPropertyChanged(nameof(EmployeeMap));
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems != null)
                    {
                        foreach (EmployeeLookupDto? item in e.OldItems.OfType<EmployeeLookupDto>())
                            if (item != null)
                                DetachEmployeeItemHandlers(item);
                        BuildLookupMaps();
                        OnPropertyChanged(nameof(EmployeeMap));
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                case NotifyCollectionChangedAction.Move:
                    BuildLookupMaps();
                    OnPropertyChanged(nameof(EmployeeMap));
                    break;
                case NotifyCollectionChangedAction.Reset:
                    foreach (var it in AvailableEmployees) DetachEmployeeItemHandlers(it);
                    foreach (var it in AvailableEmployees) AttachEmployeeItemHandlers(it);
                    BuildLookupMaps();
                    OnPropertyChanged(nameof(EmployeeMap));
                    break;
            }
        }

        private void AvailableSecurityGroups_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems != null)
                    {
                        foreach (SecurityGroupLookupDto? item in e.NewItems.OfType<SecurityGroupLookupDto>())
                            if (item != null)
                                AttachSecurityItemHandlers(item);
                        BuildLookupMaps();
                        OnPropertyChanged(nameof(SecurityMap));
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems != null)
                    {
                        foreach (SecurityGroupLookupDto? item in e.OldItems.OfType<SecurityGroupLookupDto>())
                            if (item != null)
                                DetachSecurityItemHandlers(item);
                        BuildLookupMaps();
                        OnPropertyChanged(nameof(SecurityMap));
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                case NotifyCollectionChangedAction.Move:
                    BuildLookupMaps();
                    OnPropertyChanged(nameof(SecurityMap));
                    break;
                case NotifyCollectionChangedAction.Reset:
                    foreach (var it in AvailableSecurityGroups) DetachSecurityItemHandlers(it);
                    foreach (var it in AvailableSecurityGroups) AttachSecurityItemHandlers(it);
                    BuildLookupMaps();
                    OnPropertyChanged(nameof(SecurityMap));
                    break;
            }
        }

        private void AttachEmployeeItemHandlers(EmployeeLookupDto item)
        {
            if (item is INotifyPropertyChanged npc)
                npc.PropertyChanged += EmployeeItem_PropertyChanged;
        }

        private void DetachEmployeeItemHandlers(EmployeeLookupDto item)
        {
            if (item is INotifyPropertyChanged npc)
                npc.PropertyChanged -= EmployeeItem_PropertyChanged;
        }

        private void AttachSecurityItemHandlers(SecurityGroupLookupDto item)
        {
            if (item is INotifyPropertyChanged npc)
                npc.PropertyChanged += SecurityItem_PropertyChanged;
        }

        private void DetachSecurityItemHandlers(SecurityGroupLookupDto item)
        {
            if (item is INotifyPropertyChanged npc)
                npc.PropertyChanged -= SecurityItem_PropertyChanged;
        }

        private void EmployeeItem_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (sender is not EmployeeLookupDto item) return;

            if (e.PropertyName == nameof(EmployeeLookupDto.IdNo))
            {
                BuildLookupMaps();
                OnPropertyChanged(nameof(EmployeeMap));

                // Update display text if this is the selected employee
                if (SelectedUser?.EmployeeIdNo == item.IdNo)
                    EmployeeDisplayText = item.DisplayText ?? string.Empty;

                return;
            }

            if (e.PropertyName == nameof(EmployeeLookupDto.DisplayText) || string.IsNullOrEmpty(e.PropertyName))
            {
                _employeeMap[item.IdNo] = item.DisplayText ?? string.Empty;

                // Update display text if this is the selected employee
                if (SelectedUser?.EmployeeIdNo == item.IdNo)
                    EmployeeDisplayText = item.DisplayText ?? string.Empty;

                OnPropertyChanged(nameof(EmployeeMap));
            }
        }

        private void SecurityItem_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (sender is not SecurityGroupLookupDto item) return;

            if (e.PropertyName == nameof(SecurityGroupLookupDto.IdNo))
            {
                BuildLookupMaps();
                OnPropertyChanged(nameof(SecurityMap));

                // Update display text if this is the selected security group
                if (SelectedUser?.SecurityGroupIdNo == item.IdNo)
                    SecurityGroupDisplayText = item.DisplayText ?? string.Empty;

                return;
            }

            if (e.PropertyName == nameof(SecurityGroupLookupDto.DisplayText) || string.IsNullOrEmpty(e.PropertyName))
            {
                _securityMap[item.IdNo] = item.DisplayText ?? string.Empty;

                // Update display text if this is the selected security group
                if (SelectedUser?.SecurityGroupIdNo == item.IdNo)
                    SecurityGroupDisplayText = item.DisplayText ?? string.Empty;

                OnPropertyChanged(nameof(SecurityMap));
            }
        }
    }
}