using System;
using ApplicationCore.Validations;

namespace ApplicationCore.Contract.V1.Admin.Schedule
{
    public class DeleteSingleScheduleRequest
    {
        [FutureDate(ErrorMessage = "Date must be from the future")]
        public DateTime Date { get; set; }
    }
}