using System.ComponentModel;

namespace AATM.Contracts.Dtos
{
    public class EmployeeLookupDto : INotifyPropertyChanged
    {
        public int IdNo { get; set; }

        private string _employeeCode = string.Empty;
        public string EmployeeCode
        {
            get => _employeeCode;
            set
            {
                if (_employeeCode != value)
                {
                    _employeeCode = value;
                    OnPropertyChanged(nameof(EmployeeCode));
                    OnPropertyChanged(nameof(DisplayText));
                }
            }
        }

        private string _employeeName = string.Empty;
        public string EmployeeName
        {
            get => _employeeName;
            set
            {
                if (_employeeName != value)
                {
                    _employeeName = value;
                    OnPropertyChanged(nameof(EmployeeName));
                    OnPropertyChanged(nameof(DisplayText));
                }
            }
        }

        public string DisplayText => string.IsNullOrWhiteSpace(EmployeeCode)
            ? EmployeeName
            : $"{EmployeeCode} - {EmployeeName}";

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
