using AATM.Contracts.Interfaces.Services;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace AATM.Contracts.Dtos
{
    public class TranslationDto : IEntityWithId, INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        private int _idNo;
        public int IdNo
        {
            get => _idNo;
            set { if (_idNo != value) { _idNo = value; OnPropertyChanged(nameof(IdNo)); } }
        }

        private string _moduleName = string.Empty;
        public string ModuleName
        {
            get => _moduleName;
            set
            {
                if (_moduleName != value)
                {
                    _moduleName = value;
                    OnPropertyChangedAndValidate(nameof(ModuleName));
                }
            }
        }

        private string _uiIdentifier = string.Empty;
        public string UIIdentifier
        {
            get => _uiIdentifier;
            set
            {
                if (_uiIdentifier != value)
                {
                    _uiIdentifier = value;
                    OnPropertyChangedAndValidate(nameof(UIIdentifier));
                }
            }
        }

        private string _originalString = string.Empty;
        public string OriginalString
        {
            get => _originalString;
            set
            {
                if (_originalString != value)
                {
                    _originalString = value;
                    OnPropertyChangedAndValidate(nameof(OriginalString));
                }
            }
        }

        private string _languageCode = string.Empty;
        public string LanguageCode
        {
            get => _languageCode;
            set
            {
                if (_languageCode != value)
                {
                    _languageCode = value;
                    OnPropertyChangedAndValidate(nameof(LanguageCode));
                }
            }
        }

        private string _localizedString = string.Empty;
        public string LocalizedString
        {
            get => _localizedString;
            set
            {
                if (_localizedString != value)
                {
                    _localizedString = value;
                    OnPropertyChangedAndValidate(nameof(LocalizedString));
                }
            }
        }

        private DateTime _creationDate = DateTime.Now;
        public DateTime CreationDate
        {
            get => _creationDate;
            set { if (_creationDate != value) { _creationDate = value; OnPropertyChanged(nameof(CreationDate)); } }
        }

        private readonly Dictionary<string, List<string>> _errors = new();

        public bool HasErrors => _errors.Count > 0;

        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void OnPropertyChangedAndValidate(string propertyName)
        {
            OnPropertyChanged(propertyName);
            ValidateProperty(propertyName);
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private void ValidateProperty(string propertyName)
        {
            var errors = new List<string>();

            if (propertyName == nameof(OriginalString) && string.IsNullOrWhiteSpace(OriginalString))
                errors.Add("Original string is required.");

            if (propertyName == nameof(LanguageCode) && string.IsNullOrWhiteSpace(LanguageCode))
                errors.Add("Language code is required.");

            if (propertyName == nameof(LocalizedString) && string.IsNullOrWhiteSpace(LocalizedString))
                errors.Add("Localized string is required.");

            if (propertyName == nameof(ModuleName) && string.IsNullOrWhiteSpace(ModuleName))
                errors.Add("Module name is required.");

            if (propertyName == nameof(UIIdentifier) && string.IsNullOrWhiteSpace(UIIdentifier))
                errors.Add("UI identifier is required.");

            if (errors.Count > 0)
                _errors[propertyName] = errors;
            else
                _errors.Remove(propertyName);
        }

        public IEnumerable GetErrors(string? propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                return _errors.SelectMany(e => e.Value).ToList();
            if (_errors.TryGetValue(propertyName, out var errors))
                return errors;
            return Enumerable.Empty<string>();
        }
    }
}