using System.Collections.Generic;

namespace ApplicationCore.Contract.V1.Client.Appointment.Responses
{
    public class FreeDateResponse
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLowQualityAvatarUrl { get; set; }
        public IEnumerable<DateHoursResponse> AvailableDates { get; set; }
    }
}