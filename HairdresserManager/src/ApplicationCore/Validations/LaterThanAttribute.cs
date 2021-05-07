using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Validations
{
    public class LaterThanAttribute : ValidationAttribute
    {
        private readonly string _errorMessage;
        private readonly string _otherPropertyName;

        public LaterThanAttribute(string otherPropertyName)
        {
            _otherPropertyName = otherPropertyName;
            _errorMessage = "The value of {0} must be later than {1}";
        }

        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                var otherPropertyValue = validationContext.ObjectType.GetProperty(_otherPropertyName)
                    ?.GetValue(validationContext.ObjectInstance, null);

                var earlierHour = TimeHelper.CastTo24HourFormat(otherPropertyValue.ToString());
                var laterHour = TimeHelper.CastTo24HourFormat(value.ToString());

                if (earlierHour.Item1 != laterHour.Item1)
                {
                    if (earlierHour.Item1 > laterHour.Item1)
                        return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
                else
                {
                    if (earlierHour.Item2 >= laterHour.Item2)
                        return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
            }
            catch
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(_errorMessage, name, _otherPropertyName);
        }
    }
}