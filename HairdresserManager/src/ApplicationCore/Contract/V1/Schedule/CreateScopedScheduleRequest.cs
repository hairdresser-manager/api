using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Validations;

namespace ApplicationCore.Contract.V1.Schedule
{
    public class CreateScopedScheduleRequest
    {
        [Required]  
        [FutureDate(ErrorMessage = "Date must be from the future")]
        [DataType(DataType.Date)] 
        public DateTime StartDate { get; set; }

        [Required] 
        [FutureDate(ErrorMessage = "Date must be from the future")]
        [DataType(DataType.Date)]
        [DateGreaterThan("StartDate", ErrorMessage = "EndDate must be greater than StartDate")]
        public DateTime EndDate { get; set; }

        [Required]
        [NoRepetitionsInList(ErrorMessage = "List cannot have repetitions")]
        [ContainsDaysOfWeek(ErrorMessage = "Doesn't contain days of the week")]
        public IEnumerable<string> WeekDays { get; set; }

        [Required]
        [DefaultValue("HH:mm")]
        [Is24HourFormat(ErrorMessage = "Value must be in 24 hour format")]
        public string StartHour { get; set; }

        [Required]
        [DefaultValue("HH:mm")]
        [Is24HourFormat(ErrorMessage = "Value must be in 24 hour format")]
        [LaterThan("StartHour")]
        public string EndHour { get; set; }
    }
}