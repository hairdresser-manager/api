using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contract.V1.Client.Appointment.Requests;
using ApplicationCore.Contract.V1.Client.Appointment.Responses;
using ApplicationCore.Contract.V1.General.Responses;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;

namespace WebApi.Controllers.V1.Client
{
    [ApiController]
    [Authorize(Roles = "User")]
    [Route("api/v1/appointments")]
    [ApiExplorerSettings(GroupName = "Client / Appointments")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IEmployeeService _employeeService;
        private readonly IServiceService _serviceService;
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public AppointmentController(IAppointmentService appointmentService, IEmployeeService employeeService,
            IMapper mapper, IServiceService serviceService, IClientService clientService)
        {
            _appointmentService = appointmentService;
            _employeeService = employeeService;
            _mapper = mapper;
            _serviceService = serviceService;
            _clientService = clientService;
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

        [HttpPost]
        public async Task<IActionResult> CreateAppointmentRequest([FromBody] CreateAppointmentRequest request)
        {
            var employeeAssignedToService =
                await _serviceService.EmployeeAssignedToServiceAsync(request.EmployeeId, request.ServiceId);

            if (!employeeAssignedToService)
                return BadRequest(new ErrorResponse("Employee isn't assigned to service"));

            var userId = Guid.Parse(HttpContext.GetUserId());

            var newAppointmentDto = _mapper.Map<AppointmentDto>(request);
            newAppointmentDto.ClientId = await _clientService.GetClientIdByUserId(userId);

            var result = await _appointmentService.CreateAppointmentAsync(newAppointmentDto);

            return result.Succeeded
                ? NoContent()
                : BadRequest(new ErrorResponse(result.Errors));
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointments()
        {
            var userId = Guid.Parse(HttpContext.GetUserId());
            var appointmentDtos = await _appointmentService.GetAppointmentDetailsDtosByUserIdAsync(userId);

            return appointmentDtos.Any()
                ? Ok(_mapper.Map<IEnumerable<GetAppointmentListMemberResponse>>(appointmentDtos))
                : NoContent();
        }

        [HttpDelete("{appointmentId:int}")]
        public async Task<IActionResult> CancelAppointment([FromRoute] int appointmentId)
        {
            var userId = Guid.Parse(HttpContext.GetUserId());
            var result = await _appointmentService.CancelUserAppointmentByIdAsync(userId, appointmentId);

            return result.Succeeded ? NoContent() : BadRequest(new ErrorResponse(result.Errors));
        }
    }
}