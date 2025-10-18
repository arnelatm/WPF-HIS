using AATM.Contracts.Interfaces.Services;
using System.Collections;
using System.ComponentModel;

namespace AATM.Contracts.Dtos
{
    /// <summary>
    /// Data Transfer Object for the User table, with validation and change notification.
    /// </summary>
    public class UserDto : IEntityWithId, INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        private short _idNo;
        public int IdNo
        {
            get => _idNo;
            set
            {
                if (_idNo != value)
                {
                    _idNo = (short)value;
                    OnPropertyChanged(nameof(IdNo));
                }
            }
        }

        private string _userName = string.Empty;
        public string UserName
        {
            get => _userName;
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChangedAndValidate(nameof(UserName));
                }
            }
        }

        private string? _userCode;
        public string? UserCode
        {
            get => _userCode;
            set
            {
                if (_userCode != value)
                {
                    _userCode = value;
                    OnPropertyChanged(nameof(UserCode));
                }
            }
        }

        private string? _password;
        public string? Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        private int? _employeeIdNo;
        public int? EmployeeIdNo
        {
            get => _employeeIdNo;
            set
            {
                if (_employeeIdNo != value)
                {
                    _employeeIdNo = value;
                    OnPropertyChanged(nameof(EmployeeIdNo));
                }
            }
        }

        private short? _SecurityGroupIdNo;
        public short? SecurityGroupIdNo
        {
            get => _SecurityGroupIdNo;
            set
            {
                if (_SecurityGroupIdNo != value)
                {
                    _SecurityGroupIdNo = value;
                    OnPropertyChanged(nameof(SecurityGroupIdNo));
                }
            }
        }

        private string? _fullName;
        public string? FullName
        {
            get => _fullName;
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        private string? _fullNameAra;
        public string? FullNameAra
        {
            get => _fullNameAra;
            set
            {
                if (_fullNameAra != value)
                {
                    _fullNameAra = value;
                    OnPropertyChanged(nameof(FullNameAra));
                }
            }
        }

        private byte? _securityLevel;
        public byte? SecurityLevel
        {
            get => _securityLevel;
            set
            {
                if (_securityLevel != value)
                {
                    _securityLevel = value;
                    OnPropertyChanged(nameof(SecurityLevel));
                }
            }
        }

        private bool? _active;
        public bool? Active
        {
            get => _active;
            set
            {
                if (_active != value)
                {
                    _active = value;
                    OnPropertyChanged(nameof(Active));
                }
            }
        }


        private DateTime _creationDate = DateTime.Now;
        public DateTime CreationDate
        {
            get => _creationDate;
            set { if (_creationDate != value) { _creationDate = value; OnPropertyChanged(nameof(CreationDate)); } }
        }


        // Validation
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

            if (propertyName == nameof(UserName) && string.IsNullOrWhiteSpace(UserName))
                errors.Add("User name is required.");

            if (propertyName == nameof(IdNo) && IdNo <= 0)
                errors.Add("ID must be greater than zero.");

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