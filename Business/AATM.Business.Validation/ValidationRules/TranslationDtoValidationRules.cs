using AATM.Contracts.Dtos;

namespace AATM.Business.Validation.ValidationRules
{
    public static class TranslationDtoValidationRules
    {
        public static List<string> Validate(TranslationDto dto)
        {
            var errors = new List<string>();

            if (dto == null)
            {
                errors.Add("TranslationDto cannot be null.");
                return errors;
            }

            if (string.IsNullOrWhiteSpace(dto.OriginalString))
                errors.Add("Original string is required.");

            if (string.IsNullOrWhiteSpace(dto.LanguageCode))
                errors.Add("Language code is required.");

            if (string.IsNullOrWhiteSpace(dto.LocalizedString))
                errors.Add("Localized string is required.");

            if (string.IsNullOrWhiteSpace(dto.ModuleName))
                errors.Add("Module name is required.");

            if (string.IsNullOrWhiteSpace(dto.UIIdentifier))
                errors.Add("UI identifier is required.");

            // Add more rules as needed

            return errors;
        }
    }
}