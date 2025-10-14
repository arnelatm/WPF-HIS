using System.Collections.Generic;

namespace AATM.Business.Validation.Validators
{
    public class DtoValidator<T>
    {
        private readonly Func<T, List<string>> _validateFunc;

        public DtoValidator(Func<T, List<string>> validateFunc)
        {
            _validateFunc = validateFunc;
        }

        public List<string> Validate(T dto)
        {
            return _validateFunc(dto);
        }
    }
}