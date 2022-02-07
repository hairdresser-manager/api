using System.Collections.Generic;

namespace ApplicationCore.DTOs
{
    public class FreeDateDto
    {
        public int EmployeeId { get; set; }
        public ICollection<DateHoursDto> DateHoursDto { get; set; }
    }
}