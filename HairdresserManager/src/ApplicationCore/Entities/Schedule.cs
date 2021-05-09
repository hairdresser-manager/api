using System;

namespace ApplicationCore.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public string StartingHour { get; set; }
        public string EndingHour { get; set; }

        public Employee Employee { get; set; }
    }
}