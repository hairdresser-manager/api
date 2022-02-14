using System;

namespace ApplicationCore.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }
        public DateTime Date { get; set; }

        public Appointment Appointment { get; set; }
    }
}