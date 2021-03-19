using System.Collections.Generic;
using HairdresserManager.Shared.Contract.V1;
using HairdresserManager.Shared.Contract.V1.EmployeeRoles.Requests;
using HairdresserManager.Shared.Contract.V1.EmployeeRoles.Responses;
using HairdresserManager.Shared.Results;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserManager.Api.Controllers.V1
{
    [ApiController]
    public class EmployeeRolesController : MainController
    {
        [HttpGet(ApiRoutes.EmployeeRoles.GetRoles)]
        public IActionResult GetRoles()
        {
            var response = new GetEmployeeRolesResponse
            {
                Roles = new List<string> {"Barber", "Hair dresser", "Nails"}
            };
            var result = new ServiceResult<GetEmployeeRolesResponse> {Success = true, Data = response};
            return GenerateResponse(result);
        }

        [HttpPost(ApiRoutes.EmployeeRoles.CreateRole)]
        public IActionResult CreateRole([FromBody] CreateEmployeeRoleRequest request)
        {
            var result = new ServiceResult<NoContentResult> {Success = true, ResponseCode = 201};
            return GenerateResponse(result);
        }

        [HttpPatch(ApiRoutes.EmployeeRoles.UpdateRole)]
        public IActionResult UpdateRole([FromBody] UpdateEmployeeRoleRequest request)
        {
            var result = new ServiceResult<NoContentResult> {Success = true};
            return GenerateResponse(result);
        }

        [HttpDelete(ApiRoutes.EmployeeRoles.DeleteRole)]
        public IActionResult DeleteRole()
        {
            var result = new ServiceResult<NoContentResult> {Success = true};
            return GenerateResponse(result);
        }
    }
}