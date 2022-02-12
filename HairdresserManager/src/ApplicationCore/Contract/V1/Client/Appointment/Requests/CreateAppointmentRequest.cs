using System;

namespace ApplicationCore.Contract.V1.Client.Appointment.Requests
{
    public class CreateAppointmentRequest
    { 
        public int EmployeeId { get; set; }
        public int ServiceId { get; set; }
        public DateTime Date { get; set; }
    }
}