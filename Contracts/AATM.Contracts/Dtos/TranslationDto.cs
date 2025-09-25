// This Data Transfer Object (DTO) now represents a complete localization record,
// including original string, module context, UI identifier, language code,
// localized string, and creation date.

using AATM.Contracts.Interfaces.Services;
using System;

namespace AATM.Contracts.Dtos
{
    /// <summary>
    /// Data Transfer Object for a single localized string entry.
    /// This DTO matches the columns in the Localization database table.
    /// </summary>
    public class TranslationDto : IEntityWithId
    {
        /// <summary>
        /// Unique identifier of the localization record.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The original (untranslated) source string.
        /// </summary>
        public string OriginalString { get; set; }

        /// <summary>
        /// The application module or component where the string is used.
        /// </summary>
        public string ModuleName { get; set; }

        /// <summary>
        /// UI control identifier or resource key for the string.
        /// </summary>
        public string UIIdentifier { get; set; }

        /// <summary>
        /// BCP-47 language code (e.g., en-US) for the translation.
        /// </summary>
        public string LanguageCode { get; set; }

        /// <summary>
        /// The translated text for the specified language.
        /// </summary>
        public string LocalizedString { get; set; }

        /// <summary>
        /// The date and time when the record was created.
        /// </summary>
        public DateTime CreationDate { get; set; }
    }
}