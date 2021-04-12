using System.Collections.Generic;

namespace ApplicationCore.Contract.V1.Appointment.Responses
{
    public class AvailableEmployeeDatesResponse
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLowQualityAvatar { get; set; }
        public IEnumerable<DayDatesResponse> AvailableDates { get; set; }
    }
}