// Pseudocode:
// - Identify compile-time issue: `AppDomain` may be unresolved without `using System;`.
// - Minimal, safe fix: fully qualify `AppDomain` to `System.AppDomain` in `.SetBasePath(...)`.
// - Keep the rest of the file unchanged.

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AATM.Contracts.Dtos;
using AATM.Modules.Localization;
using AATM.WpfDataAccess.Sql;
using Microsoft.Extensions.Configuration;


namespace AATM.App.HisWpf.ViewModels
{
    public class TranslationViewModel : INotifyPropertyChanged
    {
        private readonly TranslationCrudService _service;

        public ObservableCollection<TranslationDto> Translations { get; set; } = new();
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

        public TranslationViewModel()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(System.AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var connectionString = config.GetConnectionString("ISPDATA")
                ?? throw new InvalidOperationException("Connection string 'ISPDATA' is missing in appsettings.json.");

            var repository = new TranslationRepository(connectionString);
            _service = new TranslationCrudService(repository);

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