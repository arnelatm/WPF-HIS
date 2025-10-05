using AATM.Contracts.Dtos;
using System;
using System.Collections.Generic;

namespace AATM.Business.Logic.Validators
{
    public static class TranslationDtoValidationRules
    {
        public static readonly List<Func<TranslationDto, ValidationError>> Rules =
            new List<Func<TranslationDto, ValidationError>>
            {
                dto => string.IsNullOrWhiteSpace(dto.ModuleName)
                    ? new ValidationError { Property = nameof(dto.ModuleName), Message = "Module Name is required." }
                    : null,
                dto => !string.IsNullOrWhiteSpace(dto.ModuleName) && dto.ModuleName.Length > 100
                    ? new ValidationError { Property = nameof(dto.ModuleName), Message = "Module Name must not exceed 100 characters." }
                    : null,
                dto => string.IsNullOrWhiteSpace(dto.UIIdentifier)
                    ? new ValidationError { Property = nameof(dto.UIIdentifier), Message = "UI Identifier is required." }
                    : null,
                dto => string.IsNullOrWhiteSpace(dto.LanguageCode)
                    ? new ValidationError { Property = nameof(dto.LanguageCode), Message = "Language Code is required." }
                    : null,
                dto => string.IsNullOrWhiteSpace(dto.OriginalString)
                    ? new ValidationError { Property = nameof(dto.OriginalString), Message = "Original String is required." }
                    : null,
                dto => string.IsNullOrWhiteSpace(dto.LocalizedString)
                    ? new ValidationError { Property = nameof(dto.LocalizedString), Message = "Localized String is required." }
                    : null,
                // Add more rules as needed
            };
    }
}