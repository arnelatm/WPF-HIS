using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Threading.Tasks;
using AATM.Contracts.Dtos;
using AATM.Modules.Localization;

namespace AATM.App.HisWpf.ViewModels
{
    public class TranslationViewModel : INotifyPropertyChanged
    {
        private readonly TranslationCrudService _service = new TranslationCrudService();

        public ObservableCollection<TranslationDto> Translations { get; set; } = new();
        public TranslationDto? SelectedTranslation { get; set; }
        public string? ErrorText { get; set; }

        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand RefreshCommand { get; }

        public TranslationViewModel()
        {
            SaveCommand = new RelayCommand(async () => await Save(), () => SelectedTranslation != null);
            DeleteCommand = new RelayCommand(async () => await Delete(), () => SelectedTranslation != null);
            RefreshCommand = new RelayCommand(async () => await Refresh());

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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}