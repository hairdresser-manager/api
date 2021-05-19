using System;

namespace ApplicationCore.Helpers
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

            if (hour is < 0 or > 23)
                throw new InvalidCastException("Cannot cast value to 24 hour format.");

            if (minute is < 0 or > 59)
                throw new InvalidCastException("Cannot cast value to 24 hour format.");

            return (hour, minute);
        }

        public static string AddMinutes(string value, int minutesToAdd)
        {
            var (hour, minute) = CastTo24HourFormat(value);

            minute += minutesToAdd;

            if (minute > 59)
            {
                hour++;
                minute -= 60;
            }

            if (hour > 23)
                hour = 0;

            var hourString = hour < 10 ? $"0{hour}" : $"{hour}";
            var minuteString = minute < 10 ? $"0{minute}" : $"{minute}";

            return $"{hourString}:{minuteString}";
        }

        public static bool IsLessThan(string value1, string value2)
        {
            var (hour1, minute1) = CastTo24HourFormat(value1);
            var (hour2, minute2) = CastTo24HourFormat(value2);

            if (hour1 == hour2)
                if (minute1 < minute2)
                    return true;

            return hour1 < hour2;
        }
    }
}