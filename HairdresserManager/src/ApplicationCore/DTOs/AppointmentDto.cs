using System;

namespace ApplicationCore.DTOs
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public string ClientEmail { get; set; }
        public string ClientPhoneNumber { get; set; }
        public int EmployeeId { get; set; }
        public int ServiceId { get; set; }
        public DateTime Date { get; set; }
        public bool ClientDidntShowUp { get; set; }
        public bool Canceled { get; set; }
    }
}