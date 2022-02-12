using System;
using ApplicationCore.Validations;

namespace ApplicationCore.Contract.V1.Admin.Schedule
{
    public class DeleteScopedScheduleRequest
    {
        [FutureDate(ErrorMessage = "Date must be from the future")]
        public DateTime StartDate { get; set; }

        [DateGreaterThan("StartDate", ErrorMessage = "EndDate must be greater than StartDate")] 
        [FutureDate(ErrorMessage = "Date must be from the future")]
        public DateTime EndDate { get; set; }

    }
}