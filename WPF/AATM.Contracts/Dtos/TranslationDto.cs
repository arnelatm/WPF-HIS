using AATM.Contracts.Interfaces.Services;
using System.ComponentModel;

namespace AATM.Contracts.Dtos
{
    public class TranslationDto : IEntityWithId, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private int _id;
        public int ID
        {
            get => _id;
            set { if (_id != value) { _id = value; OnPropertyChanged(nameof(ID)); } }
        }

        private string _moduleName = string.Empty;
        public string ModuleName
        {
            get => _moduleName;
            set { if (_moduleName != value) { _moduleName = value; OnPropertyChanged(nameof(ModuleName)); } }
        }

        private string _uiIdentifier = string.Empty;
        public string UIIdentifier
        {
            get => _uiIdentifier;
            set { if (_uiIdentifier != value) { _uiIdentifier = value; OnPropertyChanged(nameof(UIIdentifier)); } }
        }

        private string _originalString = string.Empty;
        public string OriginalString
        {
            get => _originalString;
            set { if (_originalString != value) { _originalString = value; OnPropertyChanged(nameof(OriginalString)); } }
        }

        private string _languageCode = string.Empty;
        public string LanguageCode
        {
            get => _languageCode;
            set { if (_languageCode != value) { _languageCode = value; OnPropertyChanged(nameof(LanguageCode)); } }
        }

        private string _localizedString = string.Empty;
        public string LocalizedString
        {
            get => _localizedString;
            set { if (_localizedString != value) { _localizedString = value; OnPropertyChanged(nameof(LocalizedString)); } }
        }

        private DateTime _creationDate = DateTime.Now;
        public DateTime CreationDate
        {
            get => _creationDate;
            set { if (_creationDate != value) { _creationDate = value; OnPropertyChanged(nameof(CreationDate)); } }
        }

        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}