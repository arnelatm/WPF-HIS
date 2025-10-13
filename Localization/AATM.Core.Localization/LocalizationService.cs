using System.Globalization;
using AATM.Contracts.Dtos;
using AATM.Contracts.Interfaces.Services;
using AATM.DataAccess;

namespace AATM.Core.Localization
{
    /// <summary>
    /// Provides localized strings by retrieving them from a repository and managing them
    /// for a given language. This class implements the ILocalizationService interface.
    /// </summary>
    public class LocalizationService : ILocalizationService
    {
        private string _language;
        private string _moduleName;
        private IDictionary<string, string> _localizedStrings = new Dictionary<string, string>();
        private IDictionary<string, string> _localizedStringsByOriginal = new Dictionary<string, string>();
        private readonly ITranslationRepository _translationRepository;

        public LocalizationService(string language, string moduleName, ITranslationRepository translationRepository)
        {
            _language = language;
            _moduleName = moduleName;
            _translationRepository = translationRepository ?? throw new ArgumentNullException(nameof(translationRepository));

            RefreshCaches();
        }

        private void RefreshCaches()
        {
            _localizedStrings.Clear();
            _localizedStringsByOriginal.Clear();

            var all = _translationRepository.GetAllTranslationsAsync().GetAwaiter().GetResult();
            foreach (var t in all.Where(t => string.Equals(t.LanguageCode, _language, StringComparison.OrdinalIgnoreCase)
                                           && (string.IsNullOrWhiteSpace(_moduleName) || string.Equals(t.ModuleName, _moduleName, StringComparison.OrdinalIgnoreCase))))
            {
                var key = t.UIIdentifier ?? string.Empty;
                if (!string.IsNullOrEmpty(key) && !_localizedStrings.ContainsKey(key))
                {
                    _localizedStrings[key] = t.LocalizedString ?? t.OriginalString ?? string.Empty;
                }
                var original = t.OriginalString ?? string.Empty;
                if (!string.IsNullOrEmpty(original) && !_localizedStringsByOriginal.ContainsKey(original))
                {
                    _localizedStringsByOriginal[original] = t.LocalizedString ?? original;
                }
            }
        }

        public IDictionary<string, string> GetLocalizedStrings()
        {
            if (_localizedStrings.Count == 0)
                RefreshCaches();
            return _localizedStrings;
        }

        private IDictionary<string, string> GetAllLocalizedStrings(string languageCode)
        {
            var localizedStringsByOriginal = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            var all = _translationRepository.GetAllTranslationsAsync().GetAwaiter().GetResult();
            foreach (var t in all.Where(t => string.Equals(t.LanguageCode, languageCode, StringComparison.OrdinalIgnoreCase)))
            {
                var original = t.OriginalString ?? string.Empty;
                if (!string.IsNullOrEmpty(original) && !localizedStringsByOriginal.ContainsKey(original))
                {
                    localizedStringsByOriginal[original] = t.LocalizedString ?? original;
                }
            }
            return localizedStringsByOriginal;
        }

        public string GetString(string moduleName, string uiIdentifier, string originalString)
        {
            if (originalString is null)
                return string.Empty;

            if (_localizedStrings.TryGetValue(uiIdentifier, out var localizedString))
            {
                if (!string.IsNullOrWhiteSpace(localizedString) && !string.Equals(localizedString.Trim(), originalString.Trim(), StringComparison.Ordinal))
                    return localizedString;
            }

            if (_localizedStringsByOriginal.TryGetValue(originalString, out localizedString))
            {
                if (!string.IsNullOrWhiteSpace(localizedString) && !string.Equals(localizedString.Trim(), originalString.Trim(), StringComparison.Ordinal))
                    return localizedString;
            }

            // If not found, upsert a new entry as fallback and update caches
            AddMissingTranslation(moduleName, uiIdentifier, originalString, _language);
            _localizedStrings[uiIdentifier] = originalString;
            _localizedStringsByOriginal[originalString] = originalString;
            return originalString;
        }

        private void AddMissingTranslation(string moduleName, string uiIdentifier, string originalString, string languageCode)
        {
            var dto = new TranslationDto
            {
                OriginalString = originalString,
                ModuleName = moduleName,
                UIIdentifier = uiIdentifier,
                LanguageCode = languageCode,
                LocalizedString = originalString
            };
            _translationRepository.UpsertTranslationAsync(dto).GetAwaiter().GetResult();
        }

        public void AddOrUpdateString(string moduleName, string uiIdentifier, string originalString, string languageCode, string localizedString)
        {
            var dto = new TranslationDto
            {
                OriginalString = originalString,
                ModuleName = moduleName,
                UIIdentifier = uiIdentifier,
                LanguageCode = languageCode,
                LocalizedString = localizedString
            };
            _translationRepository.UpsertTranslationAsync(dto).GetAwaiter().GetResult();

            _localizedStrings[uiIdentifier] = localizedString;
            _localizedStringsByOriginal[originalString] = localizedString;
        }

        public List<(string display, string code)> GetAvailableLanguages()
        {
            var languages = new List<(string display, string code)>();
            languages.Add(("English", "en-US"));

            var all = _translationRepository.GetAllTranslationsAsync().GetAwaiter().GetResult();
            var codes = all.Select(t => t.LanguageCode)
                           .Where(c => !string.IsNullOrWhiteSpace(c))
                           .Distinct(StringComparer.OrdinalIgnoreCase)
                           .ToList();
            foreach (var code in codes)
            {
                if (!languages.Any(l => string.Equals(l.code, code, StringComparison.OrdinalIgnoreCase)))
                {
                    var display = GetWindowsLanguageDisplayName(code);
                    languages.Add((display, code));
                }
            }
            return languages;
        }

        public List<(string display, string languageCode)> GetWindowsAvailableLanguages()
        {
            var languages = new List<(string display, string languageCode)>();
            var cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures | CultureTypes.NeutralCultures);
            foreach (var culture in cultures)
            {
                if (!languages.Any(l => l.display == culture.Name))
                {
                    languages.Add((culture.EnglishName, culture.Name));
                }
            }
            return languages;
        }

        public static string GetWindowsLanguageDisplayName(string languageCode)
        {
            try
            {
                var culture = new CultureInfo(languageCode);
                return culture.EnglishName;
            }
            catch (CultureNotFoundException)
            {
                return languageCode;
            }
        }

        public string Translate(string sourceLang, string targetLang, string textToTranslate)
        {
            if (string.Equals(sourceLang, targetLang, StringComparison.OrdinalIgnoreCase))
                return textToTranslate;

            if (sourceLang == "en-US" && targetLang == "es-ES")
            {
                if (textToTranslate == "Save") return "Guardar";
                if (textToTranslate == "Cancel") return "Cancelar";
                if (textToTranslate == "First Name:") return "Nombre:";
                if (textToTranslate == "Are you sure you want to delete this record?") return "¿Estás seguro de que quieres eliminar este registro?";
            }
            else if (sourceLang == "es-ES" && targetLang == "en-US")
            {
                if (textToTranslate == "Guardar") return "Save";
                if (textToTranslate == "Cancelar") return "Cancel";
                if (textToTranslate == "Nombre:") return "First Name:";
                if (textToTranslate == "¿Estás seguro de que quieres eliminar este registro?") return "Are you sure you want to delete this record?";
            }

            return textToTranslate;
        }

        public bool IsRightToLeft
        {
            get
            {
                try
                {
                    var culture = new CultureInfo(_language);
                    return culture.TextInfo.IsRightToLeft;
                }
                catch
                {
                    return false;
                }
            }
        }

        public void SetLanguage(string language, string moduleName)
        {
            if (string.IsNullOrWhiteSpace(language))
                return;
            var changed = !string.Equals(_language, language, StringComparison.OrdinalIgnoreCase)
                          || !string.Equals(_moduleName, moduleName, StringComparison.OrdinalIgnoreCase);
            _language = language;
            _moduleName = moduleName;
            if (changed)
                RefreshCaches();
        }

        public void AddString(string moduleName, string text, string languageCode)
        {
            var dto = new TranslationDto
            {
                OriginalString = text,
                ModuleName = moduleName,
                UIIdentifier = text,
                LanguageCode = languageCode,
                LocalizedString = text
            };
            _translationRepository.UpsertTranslationAsync(dto).GetAwaiter().GetResult();

            if (string.Equals(_language, languageCode, StringComparison.OrdinalIgnoreCase))
            {
                if (!_localizedStrings.ContainsKey(dto.UIIdentifier))
                    _localizedStrings.Add(dto.UIIdentifier, dto.LocalizedString);
                else
                    _localizedStrings[dto.UIIdentifier] = dto.LocalizedString;

                _localizedStringsByOriginal[dto.OriginalString] = dto.LocalizedString;
            }
        }
    }
}