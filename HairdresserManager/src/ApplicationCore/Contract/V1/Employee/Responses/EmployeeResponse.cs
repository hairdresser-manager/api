using System.Collections.Generic;

namespace ApplicationCore.Contract.V1.Employee.Responses
{
    public class EmployeeResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public string AvatarUrl { get; set; }
    }
}