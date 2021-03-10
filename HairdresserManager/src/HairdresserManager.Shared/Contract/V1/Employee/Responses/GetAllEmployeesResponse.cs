using System.Collections.Generic;

namespace HairdresserManager.Shared.Contract.V1.Employee.Responses
{
    public class GetAllEmployeesResponse
    {
        public IEnumerable<EmployeeResponse> Employees { get; set; }
    }
}