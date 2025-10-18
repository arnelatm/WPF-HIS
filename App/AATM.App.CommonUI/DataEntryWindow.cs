using AATM.Contracts.Interfaces.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

public abstract class DataEntryWindow<TViewModel, TEntity> : Window
    where TViewModel : class
{
    protected TViewModel ViewModel => (TViewModel)DataContext;
    protected readonly ILocalizationService _localizationService;
    protected readonly string _moduleName;
    protected DataGrid dataGrid;
    protected Button btnSwitchLanguage;
    protected TextBox txtCurrentRecord, txtRecordCount;

    // ... cache fields for localization ...

    protected DataEntryWindow(TViewModel vm, ILocalizationService localizationService, string moduleName)
    {
        DataContext = vm;
        _localizationService = localizationService;
        _moduleName = moduleName;
        // Wire up common events in derived class after InitializeComponent
    }

    protected void SwitchLanguage()
    {
        var newLang = _localizationService.IsRightToLeft ? "en-US" : "ar-SA";
        _localizationService.SetLanguage(newLang, _moduleName);
        this.Language = XmlLanguage.GetLanguage(newLang);
        this.FlowDirection = _localizationService.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
        // Call localization helpers
    }

    // Add common navigation/filter/localization helpers here
}