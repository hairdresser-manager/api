using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contract.V1.Employee.Appointment.Requests;
using ApplicationCore.Contract.V1.Employee.Appointment.Responses;
using ApplicationCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;

namespace WebApi.Controllers.V1.Employee
{
    [ApiController]
    [Authorize(Roles = "Employee")]
    [Route("api/v1/employees/appointments")]
    [ApiExplorerSettings(GroupName = "Employee / Appointments")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public AppointmentController(IAppointmentService appointmentService, IEmployeeService employeeService, IMapper mapper)
        {
            _appointmentService = appointmentService;
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointments([FromQuery] DateTime date)
        {
            var employeeId = await _employeeService.GetEmployeeIdByUserIdAsync(HttpContext.GetUserId());
            var appointmentDetailsDtos =
                await _appointmentService.GetAppointmentDetailsDtosByEmployeeIdAsync(date, employeeId ?? 0);
            return appointmentDetailsDtos.Any()
                ? Ok(_mapper.Map<IEnumerable<GetAppointmentsListItemResponse>>(appointmentDetailsDtos))
                : NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateEmployeeAppointmentRequest request)
        {
            
            return Ok();
        }
    }
}