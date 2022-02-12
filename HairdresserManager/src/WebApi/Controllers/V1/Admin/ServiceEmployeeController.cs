using System.Threading.Tasks;
using ApplicationCore.Contract.V1.Admin.EmployeeService;
using ApplicationCore.Contract.V1.General.Responses;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1.Admin
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [ApiExplorerSettings(GroupName = "Admin / Services")]
    [Route("api/v1/services/{serviceId:int}/employees")]
    public class ServiceEmployeeController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        private readonly IEmployeeService _employeeService;
        private readonly IServiceEmployeeService _serviceEmployeeService;

        public ServiceEmployeeController(IServiceEmployeeService serviceEmployeeService,
            IEmployeeService employeeService, IServiceService serviceService)
        {
            _serviceEmployeeService = serviceEmployeeService;
            _employeeService = employeeService;
            _serviceService = serviceService;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployeeToService([FromRoute] int serviceId,
            [FromBody] AddEmployeeToServiceRequest request)
        {
            if(!await _employeeService.EmployeeExistsAsync(request.EmployeeId))
                return BadRequest(new ErrorResponse("Employee doesn't exist"));
            
            if(!await _serviceService.ServiceExistsAsync(serviceId))
                return BadRequest(new ErrorResponse("Service doesn't exist"));
            
            if (await _serviceEmployeeService.IsEmployeeInServiceAsync(request.EmployeeId, serviceId))
                return BadRequest(new ErrorResponse("Employee is already assigned to the service"));

            var result = await _serviceEmployeeService.AddEmployeeToServiceAsync(request.EmployeeId, serviceId);
            return result.Succeeded ? NoContent() : BadRequest(new ErrorResponse(result.Errors));
        }
        
        [HttpDelete]
        public async Task<IActionResult> RemoveEmployeeFromService([FromRoute] int serviceId,
            [FromBody] RemoveEmployeeFromServiceRequest request)
        {
            if (!await _serviceEmployeeService.IsEmployeeInServiceAsync(request.EmployeeId, serviceId))
                return BadRequest(new ErrorResponse("Employee isn't assigned to the service"));

            var result = await _serviceEmployeeService.RemoveEmployeeFromServiceAsync(request.EmployeeId, serviceId);
            return result.Succeeded ? NoContent() : BadRequest(new ErrorResponse(result.Errors));
        }
    }
}