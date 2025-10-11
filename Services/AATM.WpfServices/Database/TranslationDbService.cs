using AATM.Contracts.Dtos;
using AATM.WpfDataAccess; 

namespace AATM.WpfServices.Database
{
    /// <summary>
    /// Service for managing translations using the data access repository.
    /// </summary>
    public class TranslationDbService
    {
        private readonly ITranslationRepository _repository;

        // Inject the repository via constructor
        public TranslationDbService(ITranslationRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Inserts or updates a translation record.
        /// </summary>
        public async Task<TranslationDto> UpsertTranslationAsync(TranslationDto dto)
        {
            return await _repository.UpsertTranslationAsync(dto);
        }

        /// <summary>
        /// Fetches all translations.
        /// </summary>
        public async Task<List<TranslationDto>> GetAllTranslationsAsync()
        {
            return await _repository.GetAllTranslationsAsync();
        }

        /// <summary>
        /// Deletes a translation record.
        /// </summary>
        public async Task<bool> DeleteTranslationAsync(int id)
        {
            return await _repository.DeleteTranslationAsync(id);
        }

        /// <summary>
        /// Gets a translation by ID.
        /// </summary>
        public async Task<TranslationDto> GetTranslationByIdAsync(int id)
        {
            return await _repository.GetTranslationByIdAsync(id);
        }

        /// <summary>
        /// Gets a translation by string and language.
        /// </summary>
        public async Task<string> GetTranslationAsync(string originalString, string normalizedLanguage)
        {
            return await _repository.GetTranslationAsync(originalString, normalizedLanguage);
        }
    }
}