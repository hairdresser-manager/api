using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Validations
{
    public class ContainsDaysOfWeekAttribute : ValidationAttribute
    {
        private static readonly IList<string> DaysOfTheWeek = new List<string>
        {
            "monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday"
        };

        public override bool IsValid(object value)
        {
            var days = value as IList;

            if (days != null)
                foreach (var day in days)
                {
                    var stringDay = day as string;

                    if (!DaysOfTheWeek.Contains(stringDay?.ToLower()))
                        return false;
                }

            return true;
        }
    }
}