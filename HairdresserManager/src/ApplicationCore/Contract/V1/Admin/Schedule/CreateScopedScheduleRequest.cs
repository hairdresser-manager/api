using System;
using System.Collections.Generic;
using System.ComponentModel;
using ApplicationCore.Validations;

namespace ApplicationCore.Contract.V1.Admin.Schedule
{
    public class CreateScopedScheduleRequest
    {
        [FutureDate(ErrorMessage = "Date must be from the future")]
        public DateTime StartDate { get; set; }

        [FutureDate(ErrorMessage = "Date must be from the future")]
        [DateGreaterThan("StartDate", ErrorMessage = "EndDate must be greater than StartDate")]
        public DateTime EndDate { get; set; }

        [NoRepetitionsInList(ErrorMessage = "List cannot have repetitions")]
        [ContainsDaysOfWeek(ErrorMessage = "Doesn't contain days of the week")]
        public IEnumerable<string> WeekDays { get; set; }

        [DefaultValue("HH:mm")]
        [Is24HourFormat(ErrorMessage = "Value must be in 24 hour format")]
        public string StartHour { get; set; }

        [DefaultValue("HH:mm")]
        [Is24HourFormat(ErrorMessage = "Value must be in 24 hour format")]
        [LaterThan("StartHour")]
        public string EndHour { get; set; }
    }
}