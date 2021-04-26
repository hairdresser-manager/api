using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Nick { get; set; }
        public string Roles { get; set; }
        public string Description { get; set; }
        public string AvatarUrl { get; set; }
        public string LowQualityAvatarUrl { get; set; }
        
        public ICollection<Review> Reviews { get; set; }
    }
}