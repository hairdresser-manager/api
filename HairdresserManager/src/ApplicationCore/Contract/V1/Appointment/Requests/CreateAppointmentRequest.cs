using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Contract.V1.Appointment.Requests
{
    public class CreateAppointmentRequest
    {
        [Required] 
        public string EmployeeId { get; set; }
        
        [Required] 
        public string ServiceId { get; set; }
        
        [Required] 
        public string Date { get; set; }
        
        [Required] 
        public string Hour { get; set; }
    }
}