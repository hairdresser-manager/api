using System.Threading.Tasks;
using HairdresserManager.Api.Services.Interfaces;
using HairdresserManager.Shared.Contract.V1;
using HairdresserManager.Shared.Contract.V1.Employee.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserManager.Api.Controllers.V1
{
    [ApiController]
    public class EmployeeController : MainController
    {
        private readonly IEmployeeService _employeeService;
        
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        
        [HttpGet(ApiRoutes.Employee.GetAllEmployees)]
        public async Task<IActionResult> GetAllEmployees()
        {
            var result = await _employeeService.GetAllEmployeesAsync();
            return GenerateResponse(result);
        }
        
        [HttpPost(ApiRoutes.Employee.CreateEmployee)]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeRequest request)
        {
            var result = await _employeeService.CreateEmployeeAsync();
            return GenerateResponse(result);
        }
        
        [HttpPatch(ApiRoutes.Employee.UpdateEmployee)]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeRequest request)
        {
            var result = await _employeeService.UpdateEmployeeAsync();
            return GenerateResponse(result);
        }
        
        [HttpDelete(ApiRoutes.Employee.DeleteEmployee)]
        public async Task<IActionResult> DeleteEmployee()
        {
            var result = await _employeeService.DeleteEmployeeAsync();
            return GenerateResponse(result);
        }
    }
}