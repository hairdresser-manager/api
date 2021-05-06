using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Contract.V1;
using ApplicationCore.Contract.V1.Employee.Requests;
using ApplicationCore.Contract.V1.Employee.Responses;
using ApplicationCore.Contract.V1.General.Responses;
using ApplicationCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1.Employee
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IUserService userService, IMapper mapper)
        {
            _employeeService = employeeService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.Employee.GetAllEmployees)]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employeesDto = await _employeeService.GetEmployeesDtoAsync();

            var employeesResponse = new List<EmployeeResponse>();

            foreach (var employeeDto in employeesDto)
            {
                var userDto = await _userService.GetUserDtoByIdAsync(employeeDto.UserId.ToString());
                var employeeResponse = _mapper.Map<EmployeeResponse>(employeeDto);
                
                _mapper.Map(userDto, employeeResponse);
                
                employeesResponse.Add(employeeResponse);
            }
            
            return Ok(employeesResponse);
        }

        [HttpPost(ApiRoutes.Employee.CreateEmployee)]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeRequest request)
        {
            var userDto = await _userService.GetUserDtoByEmailAsync(request.Email);

            if (userDto == null)
                return BadRequest(new ErrorResponse("user doesn't exist"));

            if (await _employeeService.IsUserEmployeeAsync(userDto.Id))
                return BadRequest(new ErrorResponse("user already is an employee"));

            var employeeId = await _employeeService.AddUserToEmployees(userDto.Id);
            return Ok(new {EmployeeId = employeeId});
        }

        [HttpPut(ApiRoutes.Employee.UpdateEmployee)]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeRequest request,
            [FromRoute] int employeeId)
        {
            var employeeDto = await _employeeService.GetEmployeeDtoByIdAsync(employeeId);

            if (employeeDto == null)
                return BadRequest(new ErrorResponse("Employee doesn't exist"));

            _mapper.Map(request, employeeDto);

            var result = await _employeeService.UpdateEmployeeDataAsync(employeeDto);
            return result.Succeeded ? NoContent() : BadRequest(new ErrorResponse(result.Errors));
        }
    }
}