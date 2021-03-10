using System;
using System.Collections.Generic;

namespace HairdresserManager.Shared.Contract.V1.Employee.Responses
{
    public class EmployeeResponse
    {
        public Guid EmployeeId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public string AvatarUrl { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}