using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

public class TranslationDto : INotifyPropertyChanged, INotifyDataErrorInfo
{
    // Properties
    public int ID { get; set; }
    private string _originalString;
    public string OriginalString
    {
        get => _originalString;
        set
        {
            _originalString = value;
            OnPropertyChanged(nameof(OriginalString));
            ValidateProperty(nameof(OriginalString), value);
        }
    }
    // Repeat for other properties...

    // Validation
    private readonly Dictionary<string, List<string>> _errors = new();

    public bool HasErrors => _errors.Count > 0;
    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

    public IEnumerable GetErrors(string propertyName)
        => _errors.TryGetValue(propertyName, out var errors) ? errors : null;

    private void ValidateProperty(string propertyName, object value)
    {
        var errors = new List<string>();
        if (propertyName == nameof(OriginalString) && string.IsNullOrWhiteSpace((string)value))
            errors.Add("Original string is required.");

        // Add more rules for other properties...

        if (errors.Count > 0)
            _errors[propertyName] = errors;
        else
            _errors.Remove(propertyName);

        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}