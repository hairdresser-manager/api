namespace ApplicationCore.Contract.V1.Appointment.Requests
{
    public class CreateAppointmentRequest
    { 
        public int EmployeeId { get; set; }
        public int ServiceId { get; set; }
        public string Date { get; set; }
        public string Hour { get; set; }
    }
}