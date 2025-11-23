using System.Collections.ObjectModel;
using System.ComponentModel;
using AATM.DataAccess;
using AATM.DataAccess.Sql;

namespace AATM.Sample
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Product> Products { get; set; } = new();
        private int? _selectedProductId;
        public int? SelectedProductId
        {
            get => _selectedProductId;
            set
            {
                if (_selectedProductId != value)
                {
                    _selectedProductId = value;
                    OnPropertyChanged(nameof(SelectedProductId));
                    OnPropertyChanged(nameof(SelectedProductDisplay));
                }
            }
        }

        private string _selectedProductName;
        public string SelectedProductName
        {
            get => _selectedProductName;
            set
            {
                if (_selectedProductName != value)
                {
                    _selectedProductName = value;
                    OnPropertyChanged(nameof(SelectedProductName));
                    OnPropertyChanged(nameof(SelectedProductDisplay));
                }
            }
        }

        public string SelectedProductDisplay =>
            SelectedProductId.HasValue && !string.IsNullOrEmpty(SelectedProductName)
                ? $"{SelectedProductId} - {SelectedProductName}"
                : string.Empty;

        public MainWindowViewModel()
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            string connectionString = "Server=Ibn-Server;Database=IspData;User Id=iGroupAdmin;Password=igss@123;Encrypt=True;TrustServerCertificate=True;";
            IProductRepository repo = new ProductRepository();
            var products = repo.GetProducts(connectionString);
            foreach (var product in products)
            {
                Products.Add(product);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
