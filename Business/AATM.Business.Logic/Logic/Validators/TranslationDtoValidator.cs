using AATM.Contracts.Dtos;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AATM.Business.Logic.Validators
{
    public static class TranslationDtoValidator
    {
        public static IList<string> Validate(TranslationDto dto)
        {
            var errors = new List<string>();

            if (dto == null)
            {
                errors.Add("TranslationDto is null.");
                return errors;
            }

            if (string.IsNullOrWhiteSpace(dto.ModuleName))
                errors.Add("Module is required.");
            else if (dto.ModuleName.Length > 100)
                errors.Add("Module exceeds 100 characters.");

            if (string.IsNullOrWhiteSpace(dto.LocalizedString))
                errors.Add("Localized String is required.");

            if (string.IsNullOrWhiteSpace(dto.UIIdentifier))
                errors.Add("UI Identifier is required.");
            else if (dto.UIIdentifier.Length > 150)
                errors.Add("UI Identifier exceeds 150 characters.");

            if (string.IsNullOrWhiteSpace(dto.LanguageCode))
                errors.Add("Language code is required.");
            else if (dto.LanguageCode.Length > 10)
                errors.Add("Language code exceeds 10 characters.");
            else if (!Regex.IsMatch(dto.LanguageCode, @"^[a-z]{2,3}(-[A-Z]{2})?$"))
                errors.Add("Language code format invalid (e.g. en-US).");

            if (string.IsNullOrWhiteSpace(dto.OriginalString))
                errors.Add("Original text is required.");

            if (!string.IsNullOrEmpty(dto.ModuleName) && !string.IsNullOrEmpty(dto.UIIdentifier) &&
                dto.ModuleName.Equals(dto.UIIdentifier, System.StringComparison.OrdinalIgnoreCase))
            {
                errors.Add("UI Identifier must differ from Module.");
            }

            // Add any additional business rules here

            return errors;
        }
    }
}