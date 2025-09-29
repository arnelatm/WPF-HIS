using System.Collections.Generic;

namespace AATM.Contracts.Interfaces.Services
{
    public interface ILocalizationService
    {
        bool IsRightToLeft { get; }
        void AddOrUpdateString(string moduleName, string uiIdentifier, string originalString, string languageCode, string localizedString);
        /// <summary>
    /// Defines the contract for a translation service.
    /// </summary>
        string Translate(string sourceLang, string targetLang, string textToTranslate);
        List<(string display, string code)> GetAvailableLanguages();
        string GetString(string moduleName, string uiIdentifier, string originalString);
        IDictionary<string, string> GetLocalizedStrings();
        void AddString(string moduleName, string text, string languageCode);
        void SetLanguage(string languageCode);
    }
}