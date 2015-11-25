using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PowerExtensions
{
    public static class ValidationExtensions
    {
        private static List<ValidationResult> Errors { get; set; }

        /// <summary>
        /// Validates classes using attribute validation
        /// </summary>
        /// <typeparam name="T">Type of the class</typeparam>
        /// <param name="source">Class to validate</param>
        /// <returns></returns>
        public static bool IsValid<T>(this T source)
        {
            if (null == source)
                throw new ArgumentNullException();

            var context = new ValidationContext(source);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(source, context, results, true);
            Errors = results;
            return isValid;
        }

        /// <summary>
        /// Validation results
        /// </summary>
        /// <typeparam name="T">Type of the class</typeparam>
        /// <param name="source">Validation result for the class</param>
        /// <returns></returns>
        public static List<ValidationResult> ValidationResults<T>(this T source)
        {
            if (null == source)
                throw new ArgumentNullException();

            return Errors;
        }
    }
}
