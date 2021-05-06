using System;

namespace ApplicationCore.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public Guid UserId { get; set; }
        public string Nick { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public string AvatarUrl { get; set; }
        public string LowQualityAvatarUrl { get; set; }
    }
}