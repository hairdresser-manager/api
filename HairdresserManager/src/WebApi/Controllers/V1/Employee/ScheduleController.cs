using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contract.V1.General.Responses;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;

namespace WebApi.Controllers.V1.Employee
{
    [ApiController]
    [Authorize(Roles = "Employee")]
    [ApiExplorerSettings(GroupName = "Employee / Schedules")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        private readonly IEmployeeService _employeeService;

        public ScheduleController(IScheduleService scheduleService, IEmployeeService employeeService)
        {
            _scheduleService = scheduleService;
            _employeeService = employeeService;
        }

        [HttpGet("api/v1/schedules")]
        public async Task<IActionResult> GetSchedules()
        {
            var employeeId = await _employeeService.GetEmployeeIdByUserIdAsync(HttpContext.GetUserId());

            if (employeeId == null)
                return BadRequest(new ErrorResponse("Employee doesn't exist"));

            var schedulesDto = await _scheduleService.GetSchedulesDtoByEmployeeIdAsync((int) employeeId);

            return schedulesDto.Any() ? Ok(schedulesDto) : NotFound();
        }
    }
}