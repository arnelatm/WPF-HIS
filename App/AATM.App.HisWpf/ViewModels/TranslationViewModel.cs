using AATM.App.HisWpf.ViewModels;
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

namespace AATM.App.HisWpf.ViewModels
{
    public class TranslationViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private readonly TranslationCrudService _service;
        private readonly ILocalizationService _localizationService;

        public ObservableCollection<TranslationDto> Translations { get; } = new();
        public ObservableCollection<LanguageItem> AvailableLanguages { get; } = new();

        private TranslationDto? _selectedTranslation;
        public TranslationDto? SelectedTranslation
        {
            get => _selectedTranslation;
            set
            {
                if (_selectedTranslation != value)
                {
                    _selectedTranslation = value;
                    OnPropertyChanged();
                    ValidateAllProperties();
                }
            }
        }

        public string? ErrorText { get; set; }

        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand RefreshCommand { get; }

        public TranslationViewModel(TranslationCrudService service, ILocalizationService localizationService)
        {
            _service = service;
            _localizationService = localizationService;

            var langs = LocalizationHelper.SafeGetLanguages(_localizationService);
            foreach (var (display, code) in langs)
                AvailableLanguages.Add(new LanguageItem(display, code));

            SaveCommand = new RelayCommand(async _ => await Save(), _ => SelectedTranslation != null && !HasErrors);
            DeleteCommand = new RelayCommand(async _ => await Delete(), _ => SelectedTranslation != null);
            RefreshCommand = new RelayCommand(async _ => await Refresh());

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
            ValidateAllProperties();
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
            // Return errors for the specified property, or all errors if propertyName is null or empty
            if (string.IsNullOrEmpty(propertyName))
            {
                // Flatten all errors into a single list
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

            if (errors.Count > 0)
                _errors[propertyName] = errors;
            else
                _errors.Remove(propertyName);

            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private void ValidateAllProperties()
        {
            _errors.Clear();
            if (SelectedTranslation != null)
            {
                ValidateProperty(nameof(TranslationDto.OriginalString), SelectedTranslation.OriginalString);
                ValidateProperty(nameof(TranslationDto.LanguageCode), SelectedTranslation.LanguageCode);
                // Add more property validations as needed
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