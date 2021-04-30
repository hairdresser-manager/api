using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Nick { get; set; }
        public string Description { get; set; }
        public string AvatarUrl { get; set; }
        public string LowQualityAvatarUrl { get; set; }
        
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<EmployeeRole> Roles { get; set; }
    }
}