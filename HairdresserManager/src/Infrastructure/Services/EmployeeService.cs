using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Results;
using AutoMapper;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeService(ApplicationDbContext context, IMapper mapper, UserManager<User> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<bool> IsUserEmployeeAsync(Guid userId)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.UserId == userId);
            return employee != null;
        }

        public async Task<int> AddUserToEmployees(Guid userId)
        {
            var employee = new Employee
            {
                UserId = userId,
                Active = false
            };

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return employee.Id;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesDtoAsync()
        {
            var employees = await _context.Employees.ToListAsync();

            if (employees == null)
                return null;

            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

            foreach (var employeeDto in employeesDto)
            {
                await EmbedUserInEmployeeDtoAsync(employeeDto);
            }

            return employeesDto;
        }

        public async Task<EmployeeDto> GetEmployeeDtoByIdAsync(int employeeId)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);

            if (employee == null)
                return null;
            
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            await EmbedUserInEmployeeDtoAsync(employeeDto);
            
            return employeeDto;
        }

        public async Task<Result> UpdateEmployeeDataAsync(EmployeeDto employeeDto)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == employeeDto.Id);

            if (employee.Active != employeeDto.Active)
                await ChangeEmployeeRole(employee.UserId);
            
            _mapper.Map(employeeDto, employee);
            
            _context.Employees.Update(employee);
            return await _context.SaveChangesAsync() > 0 ? Result.Success() : Result.Failure("something went wrong");
        }

        private async Task EmbedUserInEmployeeDtoAsync(EmployeeDto employeeDto)
        {
            var user = await _userManager.FindByIdAsync(employeeDto.UserId.ToString());
            _mapper.Map(user, employeeDto);
        }

        private async Task ChangeEmployeeRole(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var roles = await _userManager.GetRolesAsync(user);

            //TODO: get rid of this hardcode
            if (roles.Contains(Role.Admin))
            {
                if (roles.Contains(Role.Employee))
                {
                    await _userManager.RemoveFromRoleAsync(user, Role.Employee);
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, Role.Employee);
                }
                
                return;
            }
            
            if (roles.Contains(Role.Employee))
            {
                await _userManager.AddToRoleAsync(user, Role.User);
                await _userManager.RemoveFromRoleAsync(user, Role.Employee);
            }
            else
            {
                await _userManager.AddToRoleAsync(user, Role.Employee);
                await _userManager.RemoveFromRoleAsync(user, Role.User);
            }
        }
    }
}