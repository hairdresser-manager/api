using System;

namespace ApplicationCore.Contract.V1.Employee.Appointment.Requests
{
    public class CreateEmployeeAppointmentRequest
    {
        public string ClientFirstName { get; set; }
        public string ClientEmail { get; set; }
        public string ClientPhoneNumber { get; set; }
        public int EmployeeId { get; set; }
        public int ServiceId { get; set; }
        public DateTime Date { get; set; }
    }
}