using AATM.Contracts.Dtos;
using AATM.Contracts.Interfaces.Services;
using AATM.Core.Localization;
using AATM.Modules.Localization;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AATM.App.HisWpf.ViewModels
{
    public class TranslationViewModel : INotifyPropertyChanged
    {
        private readonly TranslationCrudService _service;
        private readonly ILocalizationService _localizationService;

        public ObservableCollection<TranslationDto> Translations { get; } = new();
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

        public TranslationViewModel(TranslationCrudService service, ILocalizationService localizationService)
        {
            _service = service;
            _localizationService = localizationService;

            AvailableLanguages.Clear();
            var langs = LocalizationHelper.SafeGetLanguages(_localizationService);
            foreach (var (display, code) in langs)
                AvailableLanguages.Add(display);

            SaveCommand = new RelayCommand(async _ => await Save(), _ => SelectedTranslation != null);
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
}