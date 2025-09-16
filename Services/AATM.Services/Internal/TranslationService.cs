// AATM.Business/TranslationService.cs
//
// This Business Layer now operates on the new, richer TranslationDto.

using System;
using System.Globalization;
using AATM.Data;
using AATM.Contracts;
using AATM.Contracts.Dtos;

namespace AATM.Services
{
    /// <summary>
    /// Provides translation operations with simple cache-through behavior using the repository.
    /// </summary>
    public sealed class TranslationService
    {
        private const string DefaultSourceLanguage = "en";

        private readonly TranslationRepository translationRepository;
        private readonly TranslationApi translationApi;

        public TranslationService(TranslationRepository repo, TranslationApi api)
        {
            if (repo == null) throw new ArgumentNullException(nameof(repo));
            if (api == null) throw new ArgumentNullException(nameof(api));

            this.translationRepository = repo;
            this.translationApi = api;
        }

        /// <summary>
        /// Translates the specified text into the given language, returning a TranslationDto.
        /// Attempts to read from the repository first, falling back to the external API and then persisting.
        /// </summary>
        public TranslationDto Translate(string originalString, string languageCode, string moduleName, string uiIdentifier)
        {
            // Validate text
            if (string.IsNullOrWhiteSpace(originalString))
            {
                return new TranslationDto { LocalizedString = "[Error: Text to translate cannot be empty.]" };
            }

            // Normalize inputs
            originalString = originalString.Trim();
            moduleName = moduleName?.Trim();
            uiIdentifier = uiIdentifier?.Trim();

            // Validate and normalize language (BCP-47)
            string normalizedLanguage = NormalizeLanguageCode(languageCode);
            if (normalizedLanguage == null)
            {
                return new TranslationDto
                {
                    OriginalString = originalString,
                    ModuleName = moduleName,
                    UIIdentifier = uiIdentifier,
                    LanguageCode = languageCode,
                    LocalizedString = "[Error: Invalid language code.]",
                    CreationDate = DateTime.UtcNow
                };
            }

            // Try cache/database first
            TranslationDto cachedDto = translationRepository.GetTranslationFromDb(originalString, normalizedLanguage);
            if (cachedDto != null)
            {
                // This is a small improvement: we use the existing DTO and update the UI fields.
                cachedDto.ModuleName = moduleName;
                cachedDto.UIIdentifier = uiIdentifier;
                return cachedDto;
            }

            // Not in DB: call external API
            string localizedString;
            try
            {
                localizedString = translationApi.Translate(DefaultSourceLanguage, normalizedLanguage, originalString);
            }
            catch (Exception ex)
            {
                // Fail gracefully without throwing to callers (consistent with current pattern)
                return new TranslationDto
                {
                    OriginalString = originalString,
                    ModuleName = moduleName,
                    UIIdentifier = uiIdentifier,
                    LanguageCode = normalizedLanguage,
                    LocalizedString = $"[Error: Translation service failed: {ex.Message}]",
                    CreationDate = DateTime.UtcNow
                };
            }

            // Persist and return
            var newDto = BuildDto(originalString, moduleName, uiIdentifier, normalizedLanguage, localizedString);
            translationRepository.SaveTranslationToDb(newDto);

            return newDto;
        }

        private static string NormalizeLanguageCode(string languageCode)
        {
            if (string.IsNullOrWhiteSpace(languageCode)) return null;
            try
            {
                var culture = CultureInfo.GetCultureInfo(languageCode.Trim());
                return culture.Name; // canonical BCP-47 (e.g., "en-US")
            }
            catch
            {
                return null;
            }
        }

        private static TranslationDto BuildDto(string originalString, string moduleName, string uiIdentifier, string languageCode, string localized)
        {
            return new TranslationDto
            {
                // ID is typically managed by the database, so we leave it at its default (0).
                ID = 0,
                OriginalString = originalString,
                ModuleName = moduleName,
                UIIdentifier = uiIdentifier,
                LanguageCode = languageCode,
                LocalizedString = localized,
                CreationDate = DateTime.UtcNow
            };
        }
    }

    // This is the simulated API class.
    public class TranslationApi
    {
        public string Translate(string sourceLang, string targetLang, string textToTranslate)
        {
            return $"[Translated: '{textToTranslate}']";
        }
    }
}


//// MyApp.Business/TranslationService.cs
////
//// This Business Layer now operates on the new, richer TranslationDto.

//using System;
//using System.Globalization;
//using AATM.Data;
//using AATM.Contracts;

//namespace AATM.Business
//{
//    /// <summary>
//    /// Provides translation operations with simple cache-through behavior using the repository.
//    /// </summary>
//    public sealed class TranslationService
//    {
//        private const string DefaultSourceLanguage = "en";

//        private readonly TranslationRepository translationRepository;
//        private readonly TranslationApi translationApi;

//        public TranslationService(TranslationRepository repo, TranslationApi api)
//        {
//            if (repo == null) throw new ArgumentNullException(nameof(repo));
//            if (api == null) throw new ArgumentNullException(nameof(api));

//            this.translationRepository = repo;
//            this.translationApi = api;
//        }

//        /// <summary>
//        /// Translates the specified text into the given language, returning a TranslationDto.
//        /// Attempts to read from the repository first, falling back to the external API and then persisting.
//        /// </summary>
//        public TranslationDto Translate(string originalString, string languageCode, string moduleName, string uiIdentifier)
//        {
//            // Validate text
//            if (string.IsNullOrWhiteSpace(originalString))
//            {
//                return new TranslationDto { LocalizedString = "[Error: Text to translate cannot be empty.]" };
//            }

//            // Normalize inputs
//            originalString = originalString.Trim();
//            moduleName = moduleName?.Trim();
//            uiIdentifier = uiIdentifier?.Trim();

//            // Validate and normalize language (BCP-47)
//            string normalizedLanguage = NormalizeLanguageCode(languageCode);
//            if (normalizedLanguage == null)
//            {
//                return new TranslationDto
//                {
//                    OriginalString = originalString,
//                    ModuleName = moduleName,
//                    UIIdentifier = uiIdentifier,
//                    LanguageCode = languageCode,
//                    LocalizedString = "[Error: Invalid language code.]",
//                    CreationDate = DateTime.UtcNow
//                };
//            }

//            // Try cache/database first
//            string cached = translationRepository.GetTranslationFromDb(originalString, normalizedLanguage);
//            if (!string.IsNullOrEmpty(cached))
//            {
//                return BuildDto(originalString, moduleName, uiIdentifier, normalizedLanguage, cached);
//            }

//            // Not in DB: call external API
//            string localizedString;
//            try
//            {
//                localizedString = translationApi.Translate(DefaultSourceLanguage, normalizedLanguage, originalString);
//            }
//            catch (Exception ex)
//            {
//                // Fail gracefully without throwing to callers (consistent with current pattern)
//                return new TranslationDto
//                {
//                    OriginalString = originalString,
//                    ModuleName = moduleName,
//                    UIIdentifier = uiIdentifier,
//                    LanguageCode = normalizedLanguage,
//                    LocalizedString = $"[Error: Translation service failed: {ex.Message}]",
//                    CreationDate = DateTime.UtcNow
//                };
//            }

//            // Persist and return
//            translationRepository.SaveTranslationToDb(originalString, localizedString, normalizedLanguage);
//            return BuildDto(originalString, moduleName, uiIdentifier, normalizedLanguage, localizedString);
//        }

//        private static string NormalizeLanguageCode(string languageCode)
//        {
//            if (string.IsNullOrWhiteSpace(languageCode)) return null;
//            try
//            {
//                var culture = CultureInfo.GetCultureInfo(languageCode.Trim());
//                return culture.Name; // canonical BCP-47 (e.g., "en-US")
//            }
//            catch
//            {
//                return null;
//            }
//        }

//        private static TranslationDto BuildDto(string originalString, string moduleName, string uiIdentifier, string languageCode, string localized)
//        {
//            return new TranslationDto
//            {
//                OriginalString = originalString,
//                ModuleName = moduleName,
//                UIIdentifier = uiIdentifier,
//                LanguageCode = languageCode,
//                LocalizedString = localized,
//                CreationDate = DateTime.UtcNow
//            };
//        }
//    }

//    // This is the simulated API class.
//    public class TranslationApi
//    {
//        public string Translate(string sourceLang, string targetLang, string textToTranslate)
//        {
//            return $"[Translated: '{textToTranslate}']";
//        }
//    }
//}

//// MyApp.Business/TranslationService.cs
////
//// This Business Layer now operates on the new, richer TranslationDto.

//using System;
//using System.Globalization;
//using AATM.Data;
//using AATM.Contracts;

//namespace AATM.Business
//{
//    public class TranslationService
//    {
//        private readonly TranslationRepository translationRepository;
//        private readonly TranslationApi translationApi;

//        public TranslationService(TranslationRepository repo, TranslationApi api)
//        {
//            this.translationRepository = repo;
//            this.translationApi = api;
//        }

//        public TranslationDto Translate(string originalString, string languageCode, string moduleName, string uiIdentifier)
//        {
//            if (string.IsNullOrWhiteSpace(originalString))
//            {
//                return new TranslationDto { LocalizedString = "[Error: Text to translate cannot be empty.]" };
//            }

//            // Check for existing translation in the database (caching logic).
//            TranslationDto translationFromDb = translationRepository.GetTranslationFromDb(originalString, languageCode);
//            if (translationFromDb != null)
//            {
//                return translationFromDb;
//            }

//            // If not in DB, get from external service.
//            string localizedString = translationApi.Translate("en", languageCode, originalString);

//            // Create a new DTO with all the detailed data.
//            var newTranslation = new TranslationDto
//            {
//                OriginalString = originalString,
//                ModuleName = moduleName,
//                UIIdentifier = uiIdentifier,
//                LanguageCode = languageCode,
//                LocalizedString = localizedString,
//                CreationDate = DateTime.Now
//            };

//            // Save the new translation to the database.
//            translationRepository.SaveTranslationToDb(newTranslation);

//            return newTranslation;
//        }
//    }

//    // This is the simulated API class.
//    public class TranslationApi
//    {
//        public string Translate(string sourceLang, string targetLang, string textToTranslate)
//        {
//            return $"[Translated: '{textToTranslate}']";
//        }
//    }
//}
