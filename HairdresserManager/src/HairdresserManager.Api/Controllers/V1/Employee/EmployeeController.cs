using System;
using System.Collections.Generic;
using HairdresserManager.Shared.Contract.V1;
using HairdresserManager.Shared.Contract.V1.Employee.Requests;
using HairdresserManager.Shared.Contract.V1.Employee.Responses;
using HairdresserManager.Shared.Results;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserManager.Api.Controllers.V1.Employee
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet(ApiRoutes.Employee.GetAllEmployees)]
        public IActionResult GetAllEmployees()
        {
            var employees = new List<EmployeeResponse>
            {
                new()
                {
                    EmployeeId = Guid.NewGuid(), FirstName = "David", LastName = "Watts",
                    Email = "DavidEWatts@dayrep.com", Active = false,
                    Roles = new[] {"Barber", "Hair dresser"}, PhoneNumber = "6185538489",
                    Description = "person who cuts men's hair and shaves or trims beards as an occupation",
                    AvatarUrl =
                        "https://londynek.net/image/jdnews-agency/2191248/126150-201908181531-lg2.jpg.webp?t=1566138744"
                },
                new()
                {
                    EmployeeId = Guid.NewGuid(), FirstName = "Elliott", LastName = "Dubbed",
                    Email = "ElliottDubbeld@rhyta.com",
                    Roles = new[] {"No one", "Someone"}, PhoneNumber = "9702309156", Active = true,
                    Description = "person who cuts men's hair and shaves or trims beards as an occupation",
                    AvatarUrl =
                        "https://londynek.net/image/jdnews-agency/2191248/108952-201902211118-lg2.jpg.webp?t=1550747976"
                },
                new()
                {
                    EmployeeId = Guid.NewGuid(), FirstName = "Sanna", LastName = "Lok", Email = "SannaLok@teleworm.us",
                    Roles = new[] {"Aa", "Bb", "Cc"}, PhoneNumber = "6518483460", Active = true,
                    Description = "person who cuts men's hair and shaves or trims beards as an occupation",
                    AvatarUrl =
                        "https://londynek.net/image/jdnews-agency/2191248/152617-201912101211-lg2.jpg.webp?t=1575979953"
                }
            };
            
            return Ok(employees);
        }

        [HttpPost(ApiRoutes.Employee.CreateEmployee)]
        public IActionResult CreateEmployee([FromBody] CreateEmployeeRequest request)
        {
            return NoContent();
        }

        [HttpPatch(ApiRoutes.Employee.UpdateEmployee)]
        public IActionResult UpdateEmployee([FromBody] UpdateEmployeeRequest request)
        {
            return NoContent();
        }

        [HttpDelete(ApiRoutes.Employee.DeleteEmployee)]
        public IActionResult DeleteEmployee()
        {
            return NoContent();
        }
    }
}