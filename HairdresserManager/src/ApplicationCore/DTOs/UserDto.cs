using System;
using System.Collections.Generic;

namespace ApplicationCore.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilePhone { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public bool EmailConfirmed { get; set; }
    }
}