using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using AATM.Contracts.Dtos; // Reference your DTO

namespace AATM.App.Wpf.HIS.ViewModels
{
    public class TranslationViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TranslationDto> Translations { get; } = new();
        private int _currentIndex;
        public int CurrentIndex
        {
            get => _currentIndex;
            set { _currentIndex = value; OnPropertyChanged(); OnPropertyChanged(nameof(CurrentTranslation)); }
        }
        public TranslationDto? CurrentTranslation
        {
            get
            {
                return (Translations.Count > 0 && CurrentIndex >= 0 && CurrentIndex < Translations.Count)
                    ? Translations[CurrentIndex]
                    : null;
            }
        }

        // Navigation commands (same as before)
        public ICommand FirstCommand { get; }
        public ICommand PreviousCommand { get; }
        public ICommand NextCommand { get; }
        public ICommand LastCommand { get; }

        public TranslationViewModel()
        {
            FirstCommand = new RelayCommand(_ => CurrentIndex = 0, _ => Translations.Count > 0 && CurrentIndex > 0);
            PreviousCommand = new RelayCommand(_ => { if (CurrentIndex > 0) CurrentIndex--; }, _ => CurrentIndex > 0);
            NextCommand = new RelayCommand(_ => { if (CurrentIndex < Translations.Count - 1) CurrentIndex++; }, _ => CurrentIndex < Translations.Count - 1);
            LastCommand = new RelayCommand(_ => CurrentIndex = Translations.Count - 1, _ => Translations.Count > 0 && CurrentIndex < Translations.Count - 1);

            // Keep command CanExecute state in sync with property/collection changes
            PropertyChanged += (_, __) => CommandManager.InvalidateRequerySuggested();
            Translations.CollectionChanged += (_, __) => CommandManager.InvalidateRequerySuggested();

            _ = LoadTranslationsAsync();
        }

        private async Task LoadTranslationsAsync()
        {
            var service = new TranslationDbService(); // Or use dependency injection
            var dtos = await service.GetAllTranslationsAsync();
            foreach (var dto in dtos)
                Translations.Add(dto);

            CurrentIndex = 0;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}
