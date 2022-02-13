using System;

namespace ApplicationCore.DTOs
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public int Rate { get; set; }
        public DateTime Date { get; set; }
    }
}