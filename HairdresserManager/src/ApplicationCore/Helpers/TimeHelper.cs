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

            return ToString(hour, minute);
        }

        public static bool IsLessThan(string value1, string value2)
        {
            var (hour1, minute1) = CastTo24HourFormat(value1);
            var (hour2, minute2) = CastTo24HourFormat(value2);

            if (hour1 == hour2)
                return minute1 < minute2;

            return hour1 < hour2;
        }

        public static bool IsLessOrEqualTo(string value1, string value2)
        {
            var (hour1, minute1) = CastTo24HourFormat(value1);
            var (hour2, minute2) = CastTo24HourFormat(value2);

            if (hour1 == hour2)
                return minute1 <= minute2;

            return hour1 < hour2;
        }

        public static bool IsGreaterOrEqualTo(string value1, string value2)
        {
            var (hour1, minute1) = CastTo24HourFormat(value1);
            var (hour2, minute2) = CastTo24HourFormat(value2);

            if (hour1 == hour2)
                return minute1 >= minute2;

            return hour1 > hour2;
        }
        
        public static bool IsGreaterThan(string value1, string value2)
        {
            var (hour1, minute1) = CastTo24HourFormat(value1);
            var (hour2, minute2) = CastTo24HourFormat(value2);

            if (hour1 == hour2)
                return minute1 > minute2;

            return hour1 > hour2;
        }

        public static string RemoveMinutes(string value, int minutesToRemove)
        {
            var (hour, minute) = CastTo24HourFormat(value);

            if (minutesToRemove >= 60)
            {
                var hoursToRemove = minutesToRemove / 60;
                minutesToRemove = minutesToRemove - (hoursToRemove * 60);

                hour -= hoursToRemove;
                minute -= minutesToRemove;
            }
            else
            {
                minute -= minutesToRemove;
            }

            if (minute < 0)
            {
                minute = 60 + minute;
                hour--;
            }

            if (hour < 0)
                hour = 24 + hour;

            return ToString(hour, minute);
        }
        
        public static string RoundUpToQuarter(string currentHour)
        {
            var (hour, minute) = CastTo24HourFormat(currentHour);

            switch (minute)
            {
                case 0:
                    break;
                case < 15:
                    minute = 15;
                    break;
                case < 30:
                    minute = 30;
                    break;
                case < 45:
                    minute = 45;
                    break;
                case < 60:
                    minute = 0;
                    hour++;

                    if (hour > 23)
                        hour = 0;

                    break;
            }

            return ToString(hour, minute);
        }

        private static string ToString(int hour, int minute)
        {
            var hourString = hour < 10 ? $"0{hour}" : $"{hour}";
            var minuteString = minute < 10 ? $"0{minute}" : $"{minute}";

            return $"{hourString}:{minuteString}";
        }
    }
}