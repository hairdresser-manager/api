using System;

namespace ApplicationCore.DTOs
{
    public class AppointmentEmployeeDetailsDto
    {
        public int AppointmentId { get; set; }
        public DateTime Date { get; set; }
        public string ServiceName { get; set; }
        public string EmployeeNick { get; set; }
        public string EmployeeLowQualityAvatar { get; set; }
        public int? ReviewId { get; set; }
        public int? Rate { get; set; }
        public bool ClientDidntShowUp { get; set; }
        public bool Canceled { get; set; }
    }
}