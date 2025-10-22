using System.ComponentModel;

namespace AATM.Contracts.Dtos
{
    public class SecurityGroupLookupDto : INotifyPropertyChanged
    {
        public int IdNo { get; set; }

        private string _SecurityGroupCode = string.Empty;
        public string SecurityGroupCode
        {
            get => _SecurityGroupCode;
            set
            {
                if (_SecurityGroupCode != value)
                {
                    _SecurityGroupCode = value;
                    OnPropertyChanged(nameof(SecurityGroupCode));
                    OnPropertyChanged(nameof(DisplayText));
                }
            }
        }

        private string _SecurityGroupName = string.Empty;
        public string SecurityGroupName
        {
            get => _SecurityGroupName;
            set
            {
                if (_SecurityGroupName != value)
                {
                    _SecurityGroupName = value;
                    OnPropertyChanged(nameof(SecurityGroupName));
                    OnPropertyChanged(nameof(DisplayText));
                }
            }
        }

        public string DisplayText => string.IsNullOrWhiteSpace(SecurityGroupCode)
            ? SecurityGroupName
            : $"{SecurityGroupCode} - {SecurityGroupName}";

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public override string ToString()
        {
            return DisplayText; // Or whatever property you want to show
        }
    }
}
