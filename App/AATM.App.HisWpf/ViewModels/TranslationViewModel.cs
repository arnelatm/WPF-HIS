
using AATM.Contracts.Dtos;
using AATM.Contracts.Interfaces.Services;
using AATM.Core.Localization;
using AATM.DataAccess.Sql;
using AATM.Modules.Localization;
using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AATM.App.HisWpf.ViewModels
{
    public class TranslationViewModel : INotifyPropertyChanged
    {
        private readonly TranslationCrudService _service;
        private readonly ILocalizationService _localizationService;
        private readonly IConfiguration _cfg;

        public ObservableCollection<TranslationDto> Translations { get; set; } = new();
        public ObservableCollection<string> AvailableLanguages { get; } = new();
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
                }
            }
        }
        public string? ErrorText { get; set; }

        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand RefreshCommand { get; }

        public TranslationViewModel(IConfiguration cfg)
        {
            _cfg = cfg;

            var connectionString = _cfg.GetConnectionString("ISPDATA"); 
            var repository = new TranslationRepository(connectionString ?? System.Configuration.ConfigurationManager.ConnectionStrings["ISPDATA"]?.ConnectionString ?? throw new System.InvalidOperationException("Connection string 'ISPDATA' is not configured."));
            _service = new TranslationCrudService(repository);
            _localizationService = new LocalizationService("en-US", "Translation");

            AvailableLanguages.Clear();
            var langs = LocalizationHelper.SafeGetLanguages(_localizationService);
            foreach (var (display, code) in langs)
                AvailableLanguages.Add(display);

            SaveCommand = new RelayCommand(async _ => await Save(), _ => SelectedTranslation != null);
            DeleteCommand = new RelayCommand(async _ => await Delete(), _ => SelectedTranslation != null);
            RefreshCommand = new RelayCommand(async _ => await Refresh());

            _ = Refresh();
        }

        private async Task Refresh()
        {
            Translations.Clear();
            var items = await _service.GetAllAsync();
            foreach (var item in items)
                Translations.Add(item);
            // Set SelectedTranslation to the first item if available
            if (Translations.Count > 0)
                SelectedTranslation = Translations[0];
            else
                SelectedTranslation = null;
        }

        private async Task Save()
        {
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

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
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