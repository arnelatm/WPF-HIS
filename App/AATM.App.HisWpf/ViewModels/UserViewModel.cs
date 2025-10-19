using AATM.App.HisWpf.ViewModels;
using AATM.Business.Validation.ValidationRules;
using AATM.Business.Validation.Validators;
using AATM.Contracts.Dtos;
using AATM.Contracts.Interfaces.Services;
using AATM.Core.Localization;
using AATM.DataAccess;
using AATM.Modules.Localization;
using AATM.Modules.Users;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AATM.App.HisWpf.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private readonly UserCrudService _service;
        private readonly ILocalizationService _localizationService;
        private readonly IEmployeeRepository _employeeRepo;

        public ObservableCollection<UserDto> Users { get; } = new();
        public ObservableCollection<LanguageItem> AvailableLanguages { get; } = new();
        public ObservableCollection<EmployeeLookupDto> AvailableEmployees { get; } = new();
        public bool SelectedUserImplementsErrorInfo => SelectedUser is INotifyDataErrorInfo;

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

                    Debug.WriteLine($"SelectedUserImplementsErrorInfo: {SelectedUserImplementsErrorInfo}");

                    if (_selectedUser is INotifyPropertyChanged newNotify)
                        newNotify.PropertyChanged += SelectedUser_PropertyChanged;

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

        public UserViewModel(UserCrudService service, ILocalizationService localizationService, IEmployeeRepository employeeRepo)
        {
            _service = service;
            _localizationService = localizationService;
            _employeeRepo = employeeRepo;

            var langs = LocalizationHelper.SafeGetLanguages(_localizationService);
            foreach (var (display, code) in langs)
                AvailableLanguages.Add(new LanguageItem(display, code));

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

            // Load employees + users
            _ = InitializeAsync(); // instead of: _ = Refresh();
        }

        public async Task LoadEmployeesAsync()
        {
            var employees = await _employeeRepo.GetEmployeesLookupAsync().ConfigureAwait(false);
            App.Current.Dispatcher.Invoke(() =>
            {
                AvailableEmployees.Clear();
                foreach (var e in employees) AvailableEmployees.Add(e);
            });
        }
            
        public bool IsBusy { get; set; }
        private async Task Refresh()
        {
            IsBusy = true;
            OnPropertyChanged(nameof(IsBusy));
            try
            {
                Users.Clear();
                var items = await _service.GetAllAsync().ConfigureAwait(true);
                foreach (var item in items)
                    Users.Add(item);

                SelectedUser = Users.Count > 0 ? Users[0] : null;
                Debug.WriteLine($"SelectedUserImplementsErrorInfo: {SelectedUserImplementsErrorInfo}");

                ErrorText = $"Loaded {Users.Count} User(s).";
                Debug.WriteLine(ErrorText);
            }
            catch (Exception ex)
            {
                ErrorText = $"Load failed: {ex.Message}";
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
                OnPropertyChanged(nameof(IsBusy));
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

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return _errors.Values.SelectMany(e => e).ToList();
            }
            return _errors.TryGetValue(propertyName, out var errors) ? errors : Enumerable.Empty<string>();
        }

        private void ValidateProperty(string propertyName, object value)
        {
            var errors = new List<string>();
            if (propertyName == nameof(UserDto.UserName) && string.IsNullOrWhiteSpace((string)value))
                errors.Add("User Name is required.");
            if (propertyName == nameof(UserDto.SecurityGroupIdNo) && string.IsNullOrWhiteSpace((string)value))
                errors.Add("Security Group ID is required.");
            if (propertyName == nameof(UserDto.EmployeeIdNo) && string.IsNullOrWhiteSpace((string)value))
                errors.Add("Employee ID Number is required.");
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

        public async Task InitializeAsync()
        {
            await LoadEmployeesAsync();
            await Refresh();
        }
    }
}
//using System.Collections.ObjectModel;
//using System.ComponentModel;
//using System.Runtime.CompilerServices;
//using System.Windows.Input;
//using AATM.Contracts.Dtos;

//namespace AATM.App.HisWpf.ViewModels
//{
//    public class UserViewModel : INotifyPropertyChanged
//    {
//        public ObservableCollection<UserDto> User { get; } = new();
//        private UserDto? _selectedUser;
//        public UserDto? SelectedUser
//        {
//            get => _selectedUser;
//            set
//            {
//                if (_selectedUser != value)
//                {
//                    _selectedUser = value;
//                    OnPropertyChanged();
//                }
//            }
//        }

//        private bool _isBusy;
//        public bool IsBusy
//        {
//            get => _isBusy;
//            set { if (_isBusy != value) { _isBusy = value; OnPropertyChanged(); } }
//        }

//        public ICommand SaveCommand { get; }
//        public ICommand DeleteCommand { get; }

//        public event PropertyChangedEventHandler? PropertyChanged;

//        public UserViewModel()
//        {
//            // Example data for design-time/testing
//            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
//            {
//                User.Add(new UserDto { ID = 1, UserName = "admin", FullName = "Admin User" });
//                User.Add(new UserDto { ID = 2, UserName = "jdoe", FullName = "John Doe" });
//                SelectedUser = User.FirstOrDefault();
//            }

//            SaveCommand = new RelayCommand(_ => Save(), _ => SelectedUser != null && !SelectedUser.HasErrors);
//            DeleteCommand = new RelayCommand(_ => Delete(), _ => SelectedUser != null);
//        }

//        private void Save()
//        {
//            if (SelectedUser == null) return;
//            // Save logic here (e.g., update DB, call service)
//            // For demo, just ensure it's in the collection
//            if (!User.Contains(SelectedUser))
//                User.Add(SelectedUser);
//        }

//        private void Delete()
//        {
//            if (SelectedUser == null) return;
//            var toRemove = SelectedUser;
//            if (User.Contains(toRemove))
//            {
//                User.Remove(toRemove);
//                SelectedUser = User.FirstOrDefault();
//            }
//        }

//        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
//            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//    }

//    // Simple RelayCommand implementation for demo purposes
//    public class RelayCommand : ICommand
//    {
//        private readonly Action<object?> _execute;
//        private readonly Predicate<object?>? _canExecute;
//        public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
//        {
//            _execute = execute;
//            _canExecute = canExecute;
//        }
//        public bool CanExecute(object? parameter) => _canExecute == null || _canExecute(parameter);
//        public void Execute(object? parameter) => _execute(parameter);
//        public event System.EventHandler? CanExecuteChanged
//        {
//            add { CommandManager.RequerySuggested += value; }
//            remove { CommandManager.RequerySuggested -= value; }
//        }
//    }
//}