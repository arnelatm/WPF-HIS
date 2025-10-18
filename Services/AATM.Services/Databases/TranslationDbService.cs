using AATM.Contracts.Dtos;
using AATM.DataAccess;

namespace AATM.Services.Database
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
        /// Inserts or updates a translation record.
        /// </summary>
        public async Task<List<TranslationDto>> GetTranslationsPageAsync(int pageNumber, int pageSize)
        {
            return await _repository.GetTranslationsPageAsync(pageNumber, pageSize);
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
        public async Task<bool> DeleteTranslationAsync(int idNo)
        {
            return await _repository.DeleteTranslationAsync(idNo);
        }

        /// <summary>
        /// Gets a translation by IdNo.
        /// </summary>
        public async Task<TranslationDto> GetTranslationByIdAsync(int idNo)
        {
            return await _repository.GetTranslationByIdAsync(idNo);
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