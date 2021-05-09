using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Validations;

namespace ApplicationCore.Contract.V1.Schedule
{
    public class CreateSingleScheduleRequest
    {
        [Required] 
        [DataType(DataType.Date)]  
        [FutureDate(ErrorMessage = "Date must be from the future")]
        public DateTime Date { get; set; }

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