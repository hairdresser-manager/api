using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contract.V1.General.Responses;
using ApplicationCore.Contract.V1.Schedule;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1.Admin
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [ApiExplorerSettings(GroupName = "Admin / Schedules")]
    [Route("api/v1/employees/{employeeId:int}")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        private readonly IEmployeeService _employeeService;

        public ScheduleController(IScheduleService scheduleService, IEmployeeService employeeService)
        {
            _scheduleService = scheduleService;
            _employeeService = employeeService;
        }

        [HttpGet("schedules")]
        public async Task<IActionResult> GetEmployeeSchedules([FromRoute] int employeeId)
        {
            var employee = await _employeeService.GetEmployeeDtoByIdAsync(employeeId);

            if (employee == null)
                return BadRequest(new ErrorResponse("Employee doesn't exist"));

            var schedulesDto = await _scheduleService.GetSchedulesDtoByEmployeeIdAsync(employeeId);
            return schedulesDto.Any() ? Ok(schedulesDto) : NotFound();
        }

        [HttpPost("schedules")]
        public async Task<IActionResult> CreateSingleSchedule([FromRoute] int employeeId,
            [FromBody] CreateSingleScheduleRequest request)
        {
            var (isActive, errorMessage) = await IsEmployeeActiveAsync(employeeId);

            if (!isActive)
                return BadRequest(new ErrorResponse(errorMessage));

            var result = await _scheduleService.CreateScheduleAsync(employeeId, request.Date, request.StartHour,
                request.EndHour);

            return result.Succeeded ? NoContent() : BadRequest(new ErrorResponse(result.Errors));
        }

        [HttpPost("scoped-schedules")]
        public async Task<IActionResult> CreateScopedSchedule([FromRoute] int employeeId,
            [FromBody] CreateScopedScheduleRequest request)
        {
            var (isActive, errorMessage) = await IsEmployeeActiveAsync(employeeId);

            if (!isActive)
                return BadRequest(new ErrorResponse(errorMessage));

            var dates = GetDatesFromRequest(request);
            var result =
                await _scheduleService.CreateScopedScheduleAsync(employeeId, dates, request.StartHour, request.EndHour);

            return result.Succeeded ? NoContent() : BadRequest(new ErrorResponse(result.Errors));
        }

        [HttpDelete("schedules")]
        public async Task<IActionResult> DeleteSingleSchedule([FromRoute] int employeeId,
            [FromBody] DeleteSingleScheduleRequest request)
        {
            var (isActive, errorMessage) = await IsEmployeeActiveAsync(employeeId);

            if (!isActive)
                return BadRequest(new ErrorResponse(errorMessage));

            var result = await _scheduleService.DeleteScheduleAsync(employeeId, request.Date);
            return result.Succeeded ? NoContent() : BadRequest(new ErrorResponse(result.Errors));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("scoped-schedules")]
        public async Task<IActionResult> DeleteScopedSchedule([FromRoute] int employeeId,
            [FromBody] DeleteScopedScheduleRequest request)
        {
            var (isActive, errorMessage) = await IsEmployeeActiveAsync(employeeId);

            if (!isActive)
                return BadRequest(new ErrorResponse(errorMessage));

            var result =
                await _scheduleService.DeleteScopedScheduleAsync(employeeId, request.StartDate, request.EndDate);
            return result.Succeeded ? NoContent() : BadRequest(new ErrorResponse(result.Errors));
        }

        private async Task<(bool, string)> IsEmployeeActiveAsync(int employeeId)
        {
            var employeeDto = await _employeeService.GetEmployeeDtoByIdAsync(employeeId);

            if (employeeDto == null)
                return (false, "Employee doesn't exist");

            return !employeeDto.Active ? (false, "Employee isn't active") : (true, null);
        }

        //TODO: move to service in DTO object
        private IEnumerable<DateTime> GetDatesFromRequest(CreateScopedScheduleRequest request)
        {
            var dates = new List<DateTime>();
            var weekDays = request.WeekDays.Select(day => day.ToLower());
            var tempDate = request.StartDate;
            var endDate = request.EndDate;

            do
            {
                if (weekDays.Contains(tempDate.DayOfWeek.ToString().ToLower()))
                    dates.Add(tempDate);

                tempDate = tempDate.AddDays(1);
            } while (tempDate <= endDate);

            return dates;
        }
    }
}