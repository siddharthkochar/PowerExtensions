using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PowerExtensions
{
    public static class ValidationExtensions
    {
        private static List<ValidationResult> Errors { get; set; }

        public static bool IsValid<T>(this T source)
        {
            var context = new ValidationContext(source);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(source, context, results, true);
            Errors = results;
            return isValid;
        }

        public static List<ValidationResult> ValidationResults<T>(this T source)
        {
            return Errors;
        }
    }
}
