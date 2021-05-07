using System;

namespace ApplicationCore.Validations
{
    public static class TimeHelper
    {
        public static (int, int) CastTo24HourFormat(string value)
        {
            var splattedValue = value.Split(":");

            if (splattedValue.Length > 2)
                throw new InvalidCastException("Cannot cast value to 24 hour format");

            var hour = int.Parse(splattedValue[0]);
            var minute = int.Parse(splattedValue[1]);

            if (hour is < 1 or > 23)
                throw new InvalidCastException("Cannot cast value to 24 hour format.");

            if (minute is < 0 or > 59)
                throw new InvalidCastException("Cannot cast value to 24 hour format.");

            return (hour, minute);
        }
    }
}