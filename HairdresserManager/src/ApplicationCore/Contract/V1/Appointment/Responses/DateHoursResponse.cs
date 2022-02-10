using System.Collections.Generic;

namespace ApplicationCore.Contract.V1.Appointment.Responses
{
    public class DateHoursResponse
    {
        public string Date { get; set; }
        public IEnumerable<string> Hours { get; set; }
    }
}