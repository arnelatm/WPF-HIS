using System;
using System.Text.RegularExpressions;

namespace AATM.Core.Utilities
{

    /// <summary>
/// Provides a set of reusable, globally accessible utility functions for common data validation.
/// </summary>
    public sealed class ValidationUtils
    {
        private ValidationUtils()
        {
            // This is a private constructor to prevent instantiation.
        }

        /// <summary>
    /// Checks if a string value is not null, empty, or whitespace.
    /// </summary>
        public static bool IsNotNullOrEmpty(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
    /// Validates an email address using a regular expression.
    /// </summary>
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }
            // Use a standard regex pattern for email validation.
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        /// <summary>
    /// Checks if a string contains only numeric characters.
    /// </summary>
        public static bool IsNumeric(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            var regex = new Regex("^[0-9]+$");
            return regex.IsMatch(value);
        }

        /// <summary>
    /// Checks if a string has at least a specified minimum length.
    /// </summary>
        public static bool HasMinimumLength(string value, int minLength)
        {
            return value is null ? false : value.Length >= minLength;
        }

        /// <summary>
    /// Checks if a string is not longer than a specified maximum length.
    /// </summary>
        public static bool HasMaximumLength(string value, int maxLength)
        {
            return value is null ? true : value.Length <= maxLength;
        }

        /// <summary>
    /// Checks if a string contains only alphabetic characters.
    /// </summary>
        public static bool IsAlpha(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            var regex = new Regex("^[a-zA-Z]+$");
            return regex.IsMatch(value);
        }

        /// <summary>
    /// Checks if a string contains only alphanumeric characters (letters and numbers).
    /// </summary>
        public static bool IsAlphaNumeric(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            var regex = new Regex("^[a-zA-Z0-9]+$");
            return regex.IsMatch(value);
        }

        /// <summary>
    /// Checks if a string represents a positive numeric value (greater than zero).
    /// </summary>
        public static bool IsPositiveNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            double number;
            if (double.TryParse(value, out number))
            {
                return number > 0d;
            }
            return false;
        }

        /// <summary>
    /// Checks if a numeric value is within a specified range (inclusive).
    /// </summary>
        public static bool IsInRange(double value, double minValue, double maxValue)
        {
            return value >= minValue && value <= maxValue;
        }

        /// <summary>
    /// Checks if a string represents a valid date.
    /// </summary>
        public static bool IsDate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            DateTime tempDate;
            return DateTime.TryParse(value, out tempDate);
        }

        /// <summary>
    /// Checks if a string represents a positive integer (whole number greater than zero).
    /// </summary>
        public static bool IsPositiveInteger(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            int number;
            if (int.TryParse(value, out number))
            {
                return number > 0;
            }
            return false;
        }

        /// <summary>
    /// Checks if a string is a valid URL.
    /// </summary>
        public static bool IsValidUrl(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            Uri argresult = null;
            return Uri.TryCreate(value, UriKind.Absolute, out argresult);
        }

        /// <summary>
    /// A simple check for a numeric-only phone number.
    /// This is a basic check and may not cover all international formats.
    /// </summary>
        public static bool IsPhoneNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            // Simple regex for a numeric-only string
            return Regex.IsMatch(value, "^[0-9]+$");
        }

        /// <summary>
    /// Checks if a string contains any special characters.
    /// </summary>
        public static bool HasNoSpecialCharacters(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            var regex = new Regex(@"^[a-zA-Z0-9\s]+$");
            return regex.IsMatch(value);
        }

        /// <summary>
    /// Checks if a string represents a positive or zero numeric value.
    /// </summary>
        public static bool IsPositiveOrZero(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            double number;
            if (double.TryParse(value, out number))
            {
                return number >= 0d;
            }
            return false;
        }

        /// <summary>
    /// Checks if a string is a valid Guid.
    /// </summary>
        public static bool IsValidGuid(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            Guid tempGuid;
            return Guid.TryParse(value, out tempGuid);
        }

        /// <summary>
    /// Checks if a string is a valid US postal code.
    /// </summary>
        public static bool IsValidPostalCode(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            var regex = new Regex(@"^\d{5}(?:[-\s]\d{4})?$");
            return regex.IsMatch(value);
        }

        /// <summary>
    /// Checks if a date is in the future.
    /// </summary>
        public static bool IsFutureDate(DateTime value)
        {
            return value.Date > DateTime.Today.Date;
        }
    }
}