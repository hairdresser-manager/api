using System;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Validations;

namespace ApplicationCore.Contract.V1.Schedule
{
    public class DeleteScopedScheduleRequest
    {
        [Required] 
        [DataType(DataType.Date)]  
        [FutureDate(ErrorMessage = "Date must be from the future")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DateGreaterThan("StartDate", ErrorMessage = "EndDate must be greater than StartDate")] 
        [FutureDate(ErrorMessage = "Date must be from the future")]
        public DateTime EndDate { get; set; }

    }
}