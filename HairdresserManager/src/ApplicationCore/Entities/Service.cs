using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public int MinimumTime { get; set; }
        public int MaximumTime { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
        
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Appointment> Appointments  { get; set; }
        public ICollection<ServiceCategory> Categories { get; set; }
        public ICollection<ServiceEmployeeRole> EmployeeRoles { get; set; }
    }
}