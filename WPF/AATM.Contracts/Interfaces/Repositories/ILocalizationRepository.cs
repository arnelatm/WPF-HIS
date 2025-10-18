using AATM.Contracts.Dtos;
using System.Collections.Generic;

namespace AATM.Contracts.Interfaces.Repositories
{

    /// <summary>
/// Defines a contract for a data access layer responsible for retrieving localized strings.
/// This decouples the localization service from the specific data source (e.g., SQL Server, files).
/// </summary>
    public interface ILocalizationRepository
    {
        /// <summary>
    /// Gets a list of all localized strings for a given language.
    /// </summary>
    /// <param name="languageCode">The culture code for the language (e.g., "en-US", "ar-SA").</param>
    /// <returns>A list of TranslationDto objects.</returns>
        List<TranslationDto> GetLocalizedStrings(string languageCode);

        /// <summary>
    /// Adds a new localized string to the data source.
    /// </summary>
        void AddOrUpdateLocalization(string originalString, string moduleName, string uiIdentifier, string languageCode, string localizedString);
        TranslationDto GetLocalizationById(int idNo);
    }
}