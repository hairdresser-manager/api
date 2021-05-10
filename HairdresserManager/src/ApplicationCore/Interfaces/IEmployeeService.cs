using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Results;

namespace ApplicationCore.Interfaces
{
    public interface IEmployeeService
    {
        Task<bool> IsUserEmployeeAsync(Guid userId);
        Task<int> AddUserToEmployees(Guid userId);
        Task<IEnumerable<EmployeeDto>> GetEmployeesDtoAsync();
        Task<EmployeeDto> GetEmployeeDtoByIdAsync(int employeeId);
        Task<Result> UpdateEmployeeAsync(EmployeeDto employeeDto);
        Task<int?> GetEmployeeIdByUserIdAsync(string userId);
        Task<bool> EmployeeExistsAsync(int id);
    }
}