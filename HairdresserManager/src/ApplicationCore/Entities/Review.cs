using System;

namespace ApplicationCore.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int EmployeeId { get; set; }
        public int ClientId { get; set; }
        public int Rate { get; set; }
        public DateTime Date { get; set; }
    }
}