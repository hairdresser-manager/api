using System.Collections.Generic;
using System.Linq;
using HairdresserManager.Api.Extensions;
using HairdresserManager.Shared.Contract.V1.General.Requests;
using HairdresserManager.Shared.Contract.V1.General.Responses;
using HairdresserManager.Shared.Contract.V1.Resource.Requests;
using HairdresserManager.Shared.Contract.V1.Resource.Responses;
using HairdresserManager.Shared.Contract.V1.ResourceCategory.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserManager.Api.Controllers.V1
{
    [ApiController]
    public class ResourceController : MainController
    {
        [HttpGet("api/v1/resources")]
        public IActionResult GetResources([FromQuery] PaginationQueryRequest pagination)
        {
            var allResources = new List<GetResourcesResponse>
            {
                new GetResourcesResponse
                {
                    ResourceId = 1, Name = "Head&Shoulders", Category = "Shampoos",
                    Description = "This is shampoo resource", InStock = 2
                },
                new GetResourcesResponse
                {
                    ResourceId = 21, Name = "idk", Category = "Idks", Description = "This is idk resource, so idk",
                    InStock = 0, Demand = 2
                },
                new GetResourcesResponse
                {
                    ResourceId = 37, Name = "Comb", Category = "Tools",
                    Description = "This is comb resource", InStock = 1234, Demand = 2000
                }
            };

            var resources = allResources.Skip(pagination.CountItemsToSkip()).Take(pagination.PerPage);
            var metadata = new PaginationMetadataResponse(pagination, allResources.Count);
            Response.AddPaginationMetadataToHeaders(metadata);

            return StatusCode(200, resources);
        }

        [HttpPost("api/v1/resources")]
        public IActionResult CreateNewResource([FromBody] CreateResourceRequest request)
        {
            return StatusCode(201);
        }

        [HttpPatch("api/v1/resources/{resourceId}")]
        public IActionResult UpdateResource([FromBody] UpdateResourceRequest request)
        {
            return StatusCode(204);
        }

        [HttpDelete("api/v1/resources/{resourceId}")]
        public IActionResult DeleteResource([FromRoute] int resourceId)
        {
            return StatusCode(204);
        }
    }
}