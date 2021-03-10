using HairdresserManager.Shared.Contract.V1;
using HairdresserManager.Shared.Contract.V1.EmployeeRoles.Responses;
using HairdresserManager.Shared.Results;

namespace HairdresserManager.Api.Services.Interfaces
{
    public interface IEmployeeRolesService
    {
        ServiceResult<GetEmployeeRolesResponse> GetRolesAsync();
        ServiceResult<NoContentResponse> CreateRoleAsync();
        ServiceResult<NoContentResponse> UpdateRoleAsync();
        ServiceResult<NoContentResponse> DeleteRoleAsync();
    }
}