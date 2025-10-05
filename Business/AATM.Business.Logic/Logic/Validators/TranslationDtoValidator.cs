using AATM.Contracts.Dtos;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AATM.Business.Logic.Validators
{
    public static class TranslationDtoValidator
    {
        public static IEnumerable<ValidationError> ValidateWithMembers(TranslationDto dto)
        {
            if (dto == null)
                yield return new ValidationError { Property = "", Message = "TranslationDto is null." };

            if (string.IsNullOrWhiteSpace(dto.ModuleName))
                yield return new ValidationError { Property = nameof(dto.ModuleName), Message = "Module Name is required." };

            if (string.IsNullOrWhiteSpace(dto.UIIdentifier))
                yield return new ValidationError { Property = nameof(dto.UIIdentifier), Message = "UI Identifier is required." };

            if (string.IsNullOrWhiteSpace(dto.LanguageCode))
                yield return new ValidationError { Property = nameof(dto.LanguageCode), Message = "Language Code is required." };

            if (string.IsNullOrWhiteSpace(dto.OriginalString))
                yield return new ValidationError { Property = nameof(dto.OriginalString), Message = "Original String is required." };

            if (string.IsNullOrWhiteSpace(dto.LocalizedString))
                yield return new ValidationError { Property = nameof(dto.LocalizedString), Message = "Localized String is required." };

            if (!string.IsNullOrWhiteSpace(dto.ModuleName) && dto.ModuleName.Length > 100)
                yield return new ValidationError { Property = nameof(dto.ModuleName), Message = "Module Name must not exceed 100 characters." };

            // Add more rules as needed
        }
    }
}
