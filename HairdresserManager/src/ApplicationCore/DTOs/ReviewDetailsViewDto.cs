using System;

namespace ApplicationCore.DTOs
{
    public class ReviewDetailsViewDto
    {
        public int ReviewId { get; set; }
        public DateTime ReviewedDate { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int Rate { get; set; }
        public string EmployeeNick { get; set; }
        public int EmployeeId { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public string FirstName { get; set; }
    }
}