using System;
using System.Collections.Generic;
using HairdresserManager.Shared.Contract.V1.TeamMembers.Responses;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserManager.Api.Controllers.V1.Offer
{
    public class TeamMembersController : ControllerBase
    {

        [HttpGet("api/v1/team-members")]
        public IActionResult GetTeamMembers()
        {
            var employees = new List<GetTeamMemberResponse>
            {
                new()
                {
                    EmployeeId = Guid.NewGuid(), FirstName = "David",
                    Roles = new[] {"Barber", "Hair dresser"},
                    Description = "person who cuts men's hair and shaves or trims beards as an occupation",
                    AvatarUrl =
                        "https://londynek.net/image/jdnews-agency/2191248/126150-201908181531-lg2.jpg.webp?t=1566138744"
                },
                new()
                {
                    EmployeeId = Guid.NewGuid(), FirstName = "Elliott",
                    Roles = new[] {"No one", "Someone"},
                    Description = "person who cuts men's hair and shaves or trims beards as an occupation",
                    AvatarUrl =
                        "https://londynek.net/image/jdnews-agency/2191248/108952-201902211118-lg2.jpg.webp?t=1550747976"
                },
                new()
                {
                    EmployeeId = Guid.NewGuid(), FirstName = "Sanna", 
                    Roles = new[] {"Aa", "Bb", "Cc"}, 
                    Description = "person who cuts men's hair and shaves or trims beards as an occupation",
                    AvatarUrl =
                        "https://londynek.net/image/jdnews-agency/2191248/152617-201912101211-lg2.jpg.webp?t=1575979953"
                }
            };
            
            return Ok(employees);
        }
        
    }
}