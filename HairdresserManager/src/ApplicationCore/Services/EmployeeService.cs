using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Results;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IHairdresserDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public EmployeeService(IHairdresserDbContext context, IMapper mapper, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
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
            await _context.SaveChangesAsync(new CancellationToken());

            return employee.Id;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesDtoAsync()
        {
            var employees = await _context.Employees.ToListAsync();
            return employees == null ? null : _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto> GetEmployeeDtoByIdAsync(int employeeId)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);
            return employee == null ? null : _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<Result> UpdateEmployeeAsync(EmployeeDto employeeDto)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == employeeDto.Id);

            if (employee.Active != employeeDto.Active)
                await ChangeEmployeeRole(employee.UserId.ToString());

            _mapper.Map(employeeDto, employee);

            _context.Employees.Update(employee);
            var changesSaved = await _context.SaveChangesAsync(new CancellationToken()) > 0;

            return changesSaved ? Result.Success() : Result.Failure("something went wrong");
        }

        public async Task<int?> GetEmployeeIdByUserIdAsync(string userId)
        {
            var employee =
                await _context.Employees.FirstOrDefaultAsync(employee => employee.UserId.ToString().Equals(userId));

            return employee.Id;
        }

        private async Task ChangeEmployeeRole(string userId)
        {
            var roles = (IList<string>) await _userService.GetUserRolesById(userId);

            //TODO: make this in smarter way
            if (roles.Contains(Role.Admin))
            {
                if (roles.Contains(Role.Employee))
                {
                    await _userService.RemoveFromRoleAsync(userId, Role.Employee);
                }
                else
                {
                    await _userService.AddToRoleAsync(userId, Role.Employee);
                }

                return;
            }

            if (roles.Contains(Role.Employee))
            {
                await _userService.AddToRoleAsync(userId, Role.User);
                await _userService.RemoveFromRoleAsync(userId, Role.Employee);
            }
            else
            {
                await _userService.AddToRoleAsync(userId, Role.Employee);
                await _userService.RemoveFromRoleAsync(userId, Role.User);
            }
        }
    }
}