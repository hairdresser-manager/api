using System.Threading.Tasks;
using ApplicationCore.Results;

namespace ApplicationCore.Interfaces
{
    public interface IServiceEmployeeService
    {
        Task<Result> AddEmployeeToServiceAsync(int employeeId, int serviceId);
        Task<Result> RemoveEmployeeFromServiceAsync(int employeeId, int serviceId);
        Task<bool> IsEmployeeInServiceAsync(int employeeId, int serviceId);
    }
}