using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairdresserManager.Api.Services.Interfaces;
using HairdresserManager.Shared.Contract.V1;
using HairdresserManager.Shared.Contract.V1.Employee.Responses;
using HairdresserManager.Shared.Contract.V1.GeneralResponses;
using HairdresserManager.Shared.Results;

namespace HairdresserManager.Api.Services
{
    public class EmployeeService : IEmployeeService
    {
        public async Task<ServiceResult<GetAllEmployeesResponse>> GetAllEmployeesAsync()
        {
            var employees = new List<EmployeeResponse>
            {
                new()
                {
                    EmployeeId = Guid.NewGuid(), FirstName = "David", LastName = "Watts",
                    Email = "DavidEWatts@dayrep.com", Active = false,
                    Roles = new[] {"Barber", "Hair dresser"}, PhoneNumber = "6185538489",
                    Description = "person who cuts men's hair and shaves or trims beards as an occupation",
                    AvatarUrl = "https://londynek.net/image/jdnews-agency/2191248/126150-201908181531-lg2.jpg.webp?t=1566138744"
                },
                new()
                {
                    EmployeeId = Guid.NewGuid(), FirstName = "Elliott", LastName = "Dubbeld",
                    Email = "ElliottDubbeld@rhyta.com",
                    Roles = new[] {"No one", "Someone"}, PhoneNumber = "9702309156", Active = true,
                    Description = "person who cuts men's hair and shaves or trims beards as an occupation",
                    AvatarUrl = "https://londynek.net/image/jdnews-agency/2191248/108952-201902211118-lg2.jpg.webp?t=1550747976"
                },
                new()
                {
                    EmployeeId = Guid.NewGuid(), FirstName = "Sanna", LastName = "Lok", Email = "SannaLok@teleworm.us",
                    Roles = new[] {"Aa", "Bb", "Cc"}, PhoneNumber = "6518483460", Active = true,
                    Description = "person who cuts men's hair and shaves or trims beards as an occupation",
                    AvatarUrl = "https://londynek.net/image/jdnews-agency/2191248/152617-201912101211-lg2.jpg.webp?t=1575979953"
                }
            };

            var response = new GetAllEmployeesResponse {Employees = employees};
            return new ServiceResult<GetAllEmployeesResponse> {Success = true, Data = response};
        }

        public async Task<ServiceResult<NoContentResponse>> CreateEmployeeAsync()
        {
            return new() {Success = true};
        }

        public async Task<ServiceResult<NoContentResponse>> UpdateEmployeeAsync()
        {
            return new() {Success = true};
        }

        public async Task<ServiceResult<NoContentResponse>> DeleteEmployeeAsync()
        {
            return new() {Success = true};
        }
    }
}