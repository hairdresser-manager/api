using System;

namespace ApplicationCore.Contract.V1.Employee.Appointment.Responses
{
    public class GetAppointmentsListItemResponse
    {
        public int AppointmentId { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public int ServiceDuration { get; set; }
        public string ServiceName { get; set; }
    }
}