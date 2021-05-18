using System.ComponentModel.DataAnnotations;
using ApplicationCore.Helpers;

namespace ApplicationCore.Validations
{
    public class Is24HourFormatAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                TimeHelper.CastTo24HourFormat(value.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}