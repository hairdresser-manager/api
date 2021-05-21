using System.Threading.Tasks;
using ApplicationCore.Results;

namespace ApplicationCore.Interfaces
{
    public interface IServiceEmployeeService
    {
        Task<ServiceResult> AddEmployeeToServiceAsync(int employeeId, int serviceId);
        Task<ServiceResult> RemoveEmployeeFromServiceAsync(int employeeId, int serviceId);
        Task<bool> IsEmployeeInServiceAsync(int employeeId, int serviceId);
    }
}