using System;

namespace ApplicationCore.DTOs
{
    public class ScheduleDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Date { get; set; }
        public string StartingHour { get; set; }
        public string EndingHour { get; set; }
    }
}