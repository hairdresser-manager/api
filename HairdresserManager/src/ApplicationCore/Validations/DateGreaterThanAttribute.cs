using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Validations
{
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _otherPropertyName;

        public DateGreaterThanAttribute(string otherPropertyName)
        {
            _otherPropertyName = otherPropertyName;
        }

        protected override ValidationResult? IsValid(object endDateString, ValidationContext validationContext)
        {
            var startDateString = validationContext.ObjectType.GetProperty(_otherPropertyName)
                ?.GetValue(validationContext.ObjectInstance, null);

            var startDate = Convert.ToDateTime(startDateString);
            var endDate = Convert.ToDateTime(endDateString);

            if (startDate >= endDate)
                return new ValidationResult("StartDate cannot be equal or later than EndDate");

            return ValidationResult.Success;
        }
    }
}