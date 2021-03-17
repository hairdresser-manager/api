using System.Threading.Tasks;
using HairdresserManager.Shared.Contract.V1;
using HairdresserManager.Shared.Contract.V1.Employee.Responses;
using HairdresserManager.Shared.Contract.V1.GeneralResponses;
using HairdresserManager.Shared.Results;

namespace HairdresserManager.Api.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<ServiceResult<GetAllEmployeesResponse>> GetAllEmployeesAsync();
        Task<ServiceResult<NoContentResponse>> CreateEmployeeAsync();
        Task<ServiceResult<NoContentResponse>> UpdateEmployeeAsync();
        Task<ServiceResult<NoContentResponse>> DeleteEmployeeAsync();
    }
}