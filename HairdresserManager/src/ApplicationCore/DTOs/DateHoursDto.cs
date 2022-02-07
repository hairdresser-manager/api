using System;
using System.Collections.Generic;

namespace ApplicationCore.DTOs
{
    public class DateHoursDto
    {
        public DateTime Date { get; set; }
        public IEnumerable<string> Hours { get; set; }
    }
}