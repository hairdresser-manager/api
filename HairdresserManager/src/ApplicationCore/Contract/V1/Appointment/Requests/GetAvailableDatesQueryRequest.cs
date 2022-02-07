using System;
using System.Collections.Generic;

namespace ApplicationCore.Contract.V1.Appointment.Requests
{
    public class GetAvailableDatesQueryRequest
    {
        public ICollection<int> Employees { get; set; }
        public int ServiceDuration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}