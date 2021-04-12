using System.Collections.Generic;

namespace HairdresserManager.Shared.Contract.V1.Appointment.Responses
{
    public class DayDatesResponse
    {
        public string Date { get; set; }
        public IEnumerable<string> Dates { get; set; }
    }
}