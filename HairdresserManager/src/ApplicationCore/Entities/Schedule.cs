using System;

namespace ApplicationCore.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public int StartingHour { get; set; }
        public int EndingHour { get; set; }

        public Employee Employee { get; set; }
    }
}