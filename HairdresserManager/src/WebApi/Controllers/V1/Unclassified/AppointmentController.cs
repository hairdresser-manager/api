using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contract.V1.Client.Appointment.Requests;
using ApplicationCore.Contract.V1.Client.Appointment.Responses;
using ApplicationCore.Contract.V1.General.Responses;
using ApplicationCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1.Unclassified
{
    [ApiController]
    [Authorize(Roles = "User, Employee")]
    [Route("api/v1/appointments")]
    [ApiExplorerSettings(GroupName = "Unclassified / Appointments")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public AppointmentController(IAppointmentService appointmentService, IEmployeeService employeeService,
            IMapper mapper)
        {
            _appointmentService = appointmentService;
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet("available-dates")]
        public async Task<IActionResult> GetAvailableDates([FromQuery] GetAvailableDatesQueryRequest queryRequest)
        {
            var employeesDto = await _employeeService.GetEmployeesDtoAsync(queryRequest.Employees);

            var notExistingEmployees =
                queryRequest.Employees
                    .Where(employeeId => employeesDto.All(employeeDto => employeeDto.Id != employeeId))
                    .ToList();

            if (notExistingEmployees.Any())
                return BadRequest(new ErrorResponse("following employees don't exist: " +
                                                    string.Join(", ", notExistingEmployees)));

            var freeDatesDto = await _appointmentService.GetFreeDatesAsync(queryRequest.Employees,
                queryRequest.StartDate,
                queryRequest.EndDate, queryRequest.ServiceDuration);

            var response = _mapper.Map<IEnumerable<FreeDateResponse>>(employeesDto);

            foreach (var responseMember in response)
            {
                var dateHoursDto = freeDatesDto.Single(freeDate => freeDate.EmployeeId == responseMember.EmployeeId)
                    .DateHoursDto;
                responseMember.AvailableDates = _mapper.Map<IEnumerable<DateHoursResponse>>(dateHoursDto);
            }

            return Ok(response);
        }
    }
}