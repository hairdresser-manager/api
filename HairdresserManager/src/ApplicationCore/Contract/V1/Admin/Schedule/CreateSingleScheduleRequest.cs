using System;
using System.ComponentModel;
using ApplicationCore.Validations;

namespace ApplicationCore.Contract.V1.Admin.Schedule
{
    public class CreateSingleScheduleRequest
    {
        [FutureDate(ErrorMessage = "Date must be from the future")]
        public DateTime Date { get; set; }

        [DefaultValue("HH:mm")]
        [Is24HourFormat(ErrorMessage = "Value must be in 24 hour format")]
        public string StartHour { get; set; }

        [DefaultValue("HH:mm")]
        [Is24HourFormat(ErrorMessage = "Value must be in 24 hour format")]
        [LaterThan("StartHour")]
        public string EndHour { get; set; }
    }
}