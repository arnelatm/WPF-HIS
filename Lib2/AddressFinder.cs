namespace Lib2
{
    internal class AddressFinder
    {
        private AddressFinderConfigurationProvider addressFinderConfigurationProvider;

        public AddressFinder(AddressFinderConfigurationProvider addressFinderConfigurationProvider)
        {
            this.addressFinderConfigurationProvider = addressFinderConfigurationProvider;
        }

        internal Task<IList<KeyValuePair<string, string>>> CompleteAsync(string searchString)
        {
            throw new NotImplementedException();
        }
    }
}