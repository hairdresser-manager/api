using System.ComponentModel.DataAnnotations;

namespace HairdresserManager.Shared.Contract.V1.Employee.Requests
{
    public class CreateEmployeeRequest
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}