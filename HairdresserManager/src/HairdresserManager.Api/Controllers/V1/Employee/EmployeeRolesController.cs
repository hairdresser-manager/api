using System.Collections.Generic;
using HairdresserManager.Shared.Contract.V1;
using HairdresserManager.Shared.Contract.V1.EmployeeRoles.Requests;
using HairdresserManager.Shared.Contract.V1.EmployeeRoles.Responses;
using HairdresserManager.Shared.Results;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserManager.Api.Controllers.V1.Employee
{
    [ApiController]
    public class EmployeeRolesController : ControllerBase
    {
        [HttpGet(ApiRoutes.EmployeeRoles.GetRoles)]
        public IActionResult GetRoles()
        {
            var response = new GetEmployeeRolesResponse
            {
                Roles = new List<string> {"Barber", "Hair dresser", "Nails"}
            };
            
            var result = new ServiceResult<GetEmployeeRolesResponse> {Success = true, Data = response};
            
            return Ok(result.Data);
        }

        [HttpPost(ApiRoutes.EmployeeRoles.CreateRole)]
        public IActionResult CreateRole([FromBody] CreateEmployeeRoleRequest request)
        {
            return NoContent();
        }

        [HttpPatch(ApiRoutes.EmployeeRoles.UpdateRole)]
        public IActionResult UpdateRole([FromBody] UpdateEmployeeRoleRequest request)
        {
            return NoContent();
        }

        [HttpDelete(ApiRoutes.EmployeeRoles.DeleteRole)]
        public IActionResult DeleteRole()
        {
            return NoContent();
        }
    }
}