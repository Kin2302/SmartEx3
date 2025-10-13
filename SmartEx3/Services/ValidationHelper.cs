using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace SmartEx3.Services
{
    /// <summary>
    /// Utility class for data validation
    /// </summary>
    public static class ValidationHelper
    {
        public static bool ValidateObject<T>(T obj, out List<ValidationResult> validationResults)
        {
            validationResults = new List<ValidationResult>();
            var context = new ValidationContext(obj, serviceProvider: null, items: null);
            return Validator.TryValidateObject(obj, context, validationResults, true);
        }

        public static string GetValidationErrorsAsString<T>(T obj)
        {
            List<ValidationResult> validationResults;
            if (ValidateObject(obj, out validationResults))
                return string.Empty;

            return string.Join("; ", validationResults.Select(vr => vr.ErrorMessage));
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            // Password should be at least 6 characters long
            return password.Length >= 6;
        }

        public static bool IsValidAmount(decimal amount)
        {
            return amount != 0; // Allow both positive and negative amounts
        }

        public static bool IsValidDate(DateTime date)
        {
            return date >= new DateTime(1900, 1, 1) && date <= DateTime.Now.AddYears(1);
        }
    }
}