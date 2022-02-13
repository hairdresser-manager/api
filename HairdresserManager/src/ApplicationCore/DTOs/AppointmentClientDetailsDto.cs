using System;

namespace ApplicationCore.DTOs
{
    public class AppointmentClientDetailsDto
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