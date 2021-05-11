using System.Collections.Generic;

namespace ApplicationCore.DTOs
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int MinimumTime { get; set; }
        public int MaximumTime { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
        public IEnumerable<int> EmployeeIds { get; set; }
    }
}