using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Validations;

namespace ApplicationCore.Contract.V1.Schedule
{
    public class DeleteSingleScheduleRequest
    {
        [Required] 
        [DataType(DataType.Date)] 
        [FutureDate(ErrorMessage = "Date must be from the future")]
        public DateTime Date { get; set; }
    }
}