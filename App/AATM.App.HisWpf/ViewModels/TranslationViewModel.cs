using AATM.Business.Validation.ValidationRules;
using AATM.Business.Validation.Validators;
using AATM.Contracts.Dtos;
using AATM.Contracts.Interfaces.Services;
using AATM.Core.Localization;
using AATM.Modules.Localization;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AATM.App.HisWpf.ViewModels;

namespace AATM.App.HisWpf.ViewModels
{
    public class TranslationViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private readonly TranslationCrudService _service;
        private readonly ILocalizationService _localizationService;

        public ObservableCollection<TranslationDto> Translations { get; } = new();
        public ObservableCollection<LanguageItem> AvailableLanguages { get; } = new();
        public bool SelectedTranslationImplementsErrorInfo => SelectedTranslation is INotifyDataErrorInfo;

        private TranslationDto? _selectedTranslation;
        public TranslationDto? SelectedTranslation
        {
            get => _selectedTranslation;
            set
            {
                if (_selectedTranslation != value)
                {
                    if (_selectedTranslation is INotifyPropertyChanged oldNotify)
                        oldNotify.PropertyChanged -= SelectedTranslation_PropertyChanged;

                    _selectedTranslation = value;
                    OnPropertyChanged();

                    Debug.WriteLine($"SelectedTranslationImplementsErrorInfo: {SelectedTranslationImplementsErrorInfo}");

                    if (_selectedTranslation is INotifyPropertyChanged newNotify)
                        newNotify.PropertyChanged += SelectedTranslation_PropertyChanged;

                    ValidateAllProperties();
                    if (SaveCommand is AsyncRelayCommand asyncCmd)
                        asyncCmd.RaiseCanExecuteChanged();
                    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs("TranslationDto"));
                }
            }
        }

        private void SelectedTranslation_PropertyChanged(object? sender, PropertyChangedEventArgs e)
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

        private readonly DtoValidator<TranslationDto> _translationValidator =
            new DtoValidator<TranslationDto>(TranslationDtoValidationRules.Validate);

        public TranslationViewModel(TranslationCrudService service, ILocalizationService localizationService)
        {
            _service = service;
            _localizationService = localizationService;

            var langs = LocalizationHelper.SafeGetLanguages(_localizationService);
            foreach (var (display, code) in langs)
                AvailableLanguages.Add(new LanguageItem(display, code));

            SaveCommand = new AsyncRelayCommand(
                async _ => await Save(),
                _ => SelectedTranslation != null && !HasErrors
            );
            DeleteCommand = new AsyncRelayCommand(
                async _ => await Delete(),
                _ => SelectedTranslation != null
            );
            RefreshCommand = new AsyncRelayCommand(
                async _ => await Refresh()
            );

            _ = Refresh();
        }

        public bool IsBusy { get; set; }
        private async Task Refresh()
        {
            IsBusy = true;
            OnPropertyChanged(nameof(IsBusy));
            try
            {
                Translations.Clear();
                var items = await _service.GetAllAsync().ConfigureAwait(true);
                foreach (var item in items)
                    Translations.Add(item);

                SelectedTranslation = Translations.Count > 0 ? Translations[0] : null;
                Debug.WriteLine($"SelectedTranslationImplementsErrorInfo: {SelectedTranslationImplementsErrorInfo}");

                ErrorText = $"Loaded {Translations.Count} translation(s).";
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
            if (SelectedTranslation == null) return;
            var saved = await _service.UpsertAsync(SelectedTranslation);
            ErrorText = saved != null ? "" : "Save failed";
            await Refresh();
        }

        private async Task Delete()
        {
            if (SelectedTranslation == null) return;
            var ok = await _service.DeleteAsync(SelectedTranslation.ID);
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
            if (propertyName == nameof(TranslationDto.OriginalString) && string.IsNullOrWhiteSpace((string)value))
                errors.Add("Original string is required.");
            if (propertyName == nameof(TranslationDto.LanguageCode) && string.IsNullOrWhiteSpace((string)value))
                errors.Add("Language code is required.");
            if (propertyName == nameof(TranslationDto.LocalizedString) && string.IsNullOrWhiteSpace((string)value))
                errors.Add("Localized Text is required.");
            if (propertyName == nameof(TranslationDto.ModuleName) && string.IsNullOrWhiteSpace((string)value))
                errors.Add("Module Name is required.");

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
            if (SelectedTranslation != null)
            {
                var errors = _translationValidator.Validate(SelectedTranslation);
                if (errors.Any())
                {
                    _errors["TranslationDto"] = errors;
                    ErrorText = string.Join(Environment.NewLine, errors); // <-- Set error text here
                }
                else
                {
                    _errors.Remove("TranslationDto");
                }
            }
            if (SaveCommand is AsyncRelayCommand asyncCmd)
                asyncCmd.RaiseCanExecuteChanged();
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs("TranslationDto"));
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
    }

    public class LanguageItem
    {
        public string Display { get; }
        public string Code { get; }
        public LanguageItem(string display, string code)
        {
            Display = display;
            Code = code;
        }
        public override string ToString() => Display;
    }
}