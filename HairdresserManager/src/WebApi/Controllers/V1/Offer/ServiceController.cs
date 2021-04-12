using System.Collections.Generic;
using ApplicationCore.Contract.V1.Service.Requests;
using ApplicationCore.Contract.V1.Service.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1.Offer
{
    [ApiController]
    public class ServiceController : ControllerBase
    {
        [HttpGet("api/v1/services")]
        public IActionResult GetServices()
        {
            var response1 = new GetServicesResponse
            {
                ServiceId = 1, Name = "Hair cutting", Categories = new List<string> {"men cutting", "category2"},
                Employees = new List<string> {"Hubert", "Steve", "John"},
                Description = "Just a normal hair cutting",
                MinimumTime = 45, MaximumTime = 100, Price = 50
            };
            
            var response2 = new GetServicesResponse
            {
                ServiceId = 2, Name = "Hair cutting2", Categories = new List<string> {"men cutting2", "category2", "category3"},
                Employees = new List<string> {"Hubert", "Steve"},
                Description = "Just a not normal hair cutting",
                MinimumTime = 45, MaximumTime = 100, Price = 50
            };

            var response = new List<GetServicesResponse> {response1, response2};
            return Ok(response);
        }

        [HttpPost("api/v1/services")]
        public IActionResult CreateService([FromBody] CreateServiceRequest request)
        {
            return NoContent();
        }

        [HttpPatch("api/v1/services/{serviceId}")]
        public IActionResult UpdateService([FromRoute] int serviceId, [FromBody] UpdateServiceRequest request)
        {
            return NoContent();
        }

        [HttpDelete("api/v1/services/{serviceId}")]
        public IActionResult DeleteService([FromRoute] int serviceId)
        {
            return NoContent();
        }
    }
}