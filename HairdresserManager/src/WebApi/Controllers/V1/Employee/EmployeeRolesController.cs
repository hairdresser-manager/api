using System.Collections.Generic;
using ApplicationCore.Contract.V1;
using ApplicationCore.Contract.V1.EmployeeRoles.Requests;
using ApplicationCore.Contract.V1.EmployeeRoles.Responses;
using ApplicationCore.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1.Employee
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
            
            return Ok(response);
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