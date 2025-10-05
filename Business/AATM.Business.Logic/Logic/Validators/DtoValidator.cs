using System;
using System.Collections.Generic;

namespace AATM.Business.Logic.Validators
{
    public static class DtoValidator
    {
        public static IEnumerable<ValidationError> Validate<T>(
            T dto,
            IEnumerable<Func<T, ValidationError>> rules)
        {
            if (dto == null)
            {
                yield return new ValidationError { Property = "", Message = $"{typeof(T).Name} is null." };
                yield break;
            }

            foreach (var rule in rules)
            {
                var error = rule(dto);
                if (error != null)
                    yield return error;
            }
        }
    }
}