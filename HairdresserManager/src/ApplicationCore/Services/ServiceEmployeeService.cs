using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Results;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Services
{
    public class ServiceEmployeeService : IServiceEmployeeService
    {
        private readonly IHairdresserDbContext _context;

        public ServiceEmployeeService(IHairdresserDbContext context)
        {
            _context = context;
        }

        public async Task<Result> AddEmployeeToServiceAsync(int employeeId, int serviceId)
        {
            var employeeService = new ApplicationCore.Entities.EmployeeService
                {EmployeeId = employeeId, ServiceId = serviceId};

            await _context.EmployeeService.AddAsync(employeeService);
            return await _context.SaveChangesAsync(new CancellationToken()) > 0
                ? Result.Success()
                : Result.Failure("Something went wrong");
        }

        public async Task<Result> RemoveEmployeeFromServiceAsync(int employeeId, int serviceId)
        {
            var employeeService =
                await _context.EmployeeService.FirstOrDefaultAsync(e =>
                    e.EmployeeId == employeeId && e.ServiceId == serviceId);

            if (employeeService == null)
                return Result.Failure("Employee isn't assigned to this service");

            _context.EmployeeService.Remove(employeeService);
            return await _context.SaveChangesAsync(new CancellationToken()) > 0
                ? Result.Success()
                : Result.Failure("Something went wrong");
        }

        public async Task<bool> IsEmployeeInServiceAsync(int employeeId, int serviceId) =>
            await _context.EmployeeService
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId && e.ServiceId == serviceId) != null;
    }
}