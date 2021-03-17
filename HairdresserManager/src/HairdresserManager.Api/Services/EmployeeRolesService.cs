using System.Collections.Generic;
using HairdresserManager.Api.Services.Interfaces;
using HairdresserManager.Shared.Contract.V1;
using HairdresserManager.Shared.Contract.V1.EmployeeRoles.Responses;
using HairdresserManager.Shared.Contract.V1.GeneralResponses;
using HairdresserManager.Shared.Results;

namespace HairdresserManager.Api.Services
{
    public class EmployeeRolesService : IEmployeeRolesService
    {
        public ServiceResult<GetEmployeeRolesResponse> GetRolesAsync()
        {
            var response = new GetEmployeeRolesResponse
            {
                Roles = new List<string> {"Barber", "Hair dresser", "Nails"}
            };
            return new() {Success = true, Data = response};
        }

        public ServiceResult<NoContentResponse> CreateRoleAsync()
        {
            return new() {Success = true, ResponseCode = 201};
        }

        public ServiceResult<NoContentResponse> UpdateRoleAsync()
        {
            return new() {Success = true};
        }

        public ServiceResult<NoContentResponse> DeleteRoleAsync()
        {
            return new() {Success = true};
        }
    }
}