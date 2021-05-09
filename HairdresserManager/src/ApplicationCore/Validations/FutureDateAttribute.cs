using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Validations
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                return Convert.ToDateTime(value) >= DateTime.Now || value == null
                    ? ValidationResult.Success
                    : new ValidationResult(ErrorMessage);
            }
            catch
            {
                return new ValidationResult(ErrorMessage);
            }
        }
    }
}