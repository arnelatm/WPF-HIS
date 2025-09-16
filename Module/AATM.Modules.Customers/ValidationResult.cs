
namespace AATM.Modules.Customers
{
    /// <summary>
/// A class to represent the result of a validation operation,
/// used for returning success or failure with a message.
/// </summary>
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }

        public static ValidationResult Success()
        {
            return new ValidationResult() { IsValid = true };
        }

        public static ValidationResult Fail(string message)
        {
            return new ValidationResult() { IsValid = false, ErrorMessage = message };
        }
    }
}