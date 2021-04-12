using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Contract.V1.Employee.Requests
{
    public class CreateEmployeeRequest
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}