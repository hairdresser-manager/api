using HairdresserManager.Api.Services.Interfaces;
using HairdresserManager.Shared.Contract.V1;
using HairdresserManager.Shared.Contract.V1.EmployeeRoles.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserManager.Api.Controllers.V1
{
    [ApiController]
    public class EmployeeRolesController : MainController
    {
        private readonly IEmployeeRolesService _employeeRolesService;

        public EmployeeRolesController(IEmployeeRolesService employeeRolesService)
        {
            _employeeRolesService = employeeRolesService;
        }

        [HttpGet(ApiRoutes.EmployeeRoles.GetRoles)]
        public IActionResult GetRoles()
        {
            var result = _employeeRolesService.GetRolesAsync();
            return GenerateResponse(result);
        }
        
        [HttpPost(ApiRoutes.EmployeeRoles.CreateRole)]
        public IActionResult CreateRole([FromBody] CreateEmployeeRoleRequest request)
        {
            var result = _employeeRolesService.CreateRoleAsync();
            return GenerateResponse(result);
        }
        
        [HttpPatch(ApiRoutes.EmployeeRoles.UpdateRole)]
        public IActionResult UpdateRole([FromBody] UpdateEmployeeRoleRequest request)
        {
            var result = _employeeRolesService.UpdateRoleAsync();
            return GenerateResponse(result);
        }
        
        [HttpDelete(ApiRoutes.EmployeeRoles.DeleteRole)]
        public IActionResult DeleteRole()
        {
            var result = _employeeRolesService.DeleteRoleAsync();
            return GenerateResponse(result);
        }
    }
}