using System.Collections.Generic;

namespace ApplicationCore.Contract.V1.EmployeeRoles.Responses
{
    public class GetEmployeeRolesResponse
    {
        public IEnumerable<string> Roles { get; set; }
    }
}