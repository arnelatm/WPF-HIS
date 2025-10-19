using AATM.Contracts.Dtos;

namespace AATM.Business.Validation.ValidationRules
{
    public static class UserDtoValidationRules
    {
        public static List<string> Validate(UserDto dto)
        {
            var errors = new List<string>();

            if (dto == null)
            {
                errors.Add("UserDto cannot be null.");
                return errors;
            }

            if (dto.IdNo <= 0)
                errors.Add("ID Number must be greater than zero.");

            if (string.IsNullOrWhiteSpace(dto.UserName))
                errors.Add("User name is required.");

            if (dto.UserName != null && dto.UserName.Length > 20)
                errors.Add("User name cannot exceed 20 characters.");

            // SecurityLevel: byte? (tinyint), no range check unless business rule needed

            // Active: bool? (bit), no validation needed

            // DateTimeStamp: byte[]? (timestamp), no validation needed

            // EmployeeIdNo, SecurityGroupIDNo: nullable, no validation needed

            return errors;
        }
    }
}