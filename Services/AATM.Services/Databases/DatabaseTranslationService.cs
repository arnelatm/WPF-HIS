using AATM.Contracts.Dtos;
using AATM.Contracts.Interfaces.Business;
using AATM.DataAccess;
using Microsoft.Extensions.Caching.Memory;


namespace AATM.Services.Databases
{
    public class DatabaseTranslationService : ITranslationService
    {
        private readonly ITranslationRepository _repository;
        private readonly ITranslationApi _translationApi;
        private readonly IMemoryCache _cache;
        private readonly TimeSpan _cacheDuration = TimeSpan.FromMinutes(10);

        public DatabaseTranslationService(
            ITranslationRepository repository,
            ITranslationApi translationApi,
            IMemoryCache cache)
        {
            _repository = repository;
            _translationApi = translationApi;
            _cache = cache;
        }

        public async Task<string> TranslateAsync(string sourceText, string targetLanguage)
        {
            string cacheKey = $"{sourceText}:{targetLanguage}";
            if (_cache.TryGetValue(cacheKey, out string translatedText) && !string.IsNullOrEmpty(translatedText))
                return translatedText;

            translatedText = await _repository.GetTranslationAsync(sourceText, targetLanguage).ConfigureAwait(false);

            if (string.IsNullOrEmpty(translatedText))
            {
                translatedText = await _translationApi.GetTranslationAsync(sourceText, targetLanguage).ConfigureAwait(false);
                if (!string.IsNullOrEmpty(translatedText))
                    await _repository.UpsertTranslationAsync(new TranslationDto
                    {
                        OriginalString = sourceText,
                        ModuleName = sourceText,
                        UIIdentifier = sourceText,
                        LanguageCode = targetLanguage,
                        LocalizedString = translatedText,
                        CreationDate = DateTime.Now
                    }).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(translatedText))
                _cache.Set(cacheKey, translatedText, DateTimeOffset.Now.Add(_cacheDuration));

            return translatedText ?? string.Empty;
        }
    }
}