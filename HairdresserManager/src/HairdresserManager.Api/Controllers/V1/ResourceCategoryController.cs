using System.Collections.Generic;
using HairdresserManager.Shared.Contract.V1.ResourceCategory.Requests;
using HairdresserManager.Shared.Contract.V1.ResourceCategory.Responses;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserManager.Api.Controllers.V1
{
    [ApiController]
    public class ResourceCategoryController : MainController
    {
        [HttpGet("api/v1/resources/categories")]
        public IActionResult GetAllResourcesCategories()
        {
            var resourcesCategories = new List<ResourcesCategoryResponse>
            {
                new ResourcesCategoryResponse{ResourcesCategoryId = 1, Name = "category1", Description = "descirption lorem ipsum"},
                new ResourcesCategoryResponse{ResourcesCategoryId = 2, Name = "category2", Description = "descirption lorem fadsfadsf ipsum"},
                new ResourcesCategoryResponse{ResourcesCategoryId = 3, Name = "fsadf", Description = "descirption fasdfsdf"},
            };
            
            return StatusCode(200, resourcesCategories);
        }

        [HttpPost("api/v1/resources/categories")]
        public IActionResult CreateNewResourceCategory([FromBody] CreateResourcesCategoryRequest request)
        {
            return StatusCode(201);
        }

        [HttpPatch("api/v1/resources/categories/{categoryId}")]
        public IActionResult UpdateResourceCategory([FromBody] UpdateResourcesCategoryRequest request)
        {
            return StatusCode(204);
        }

        [HttpDelete("api/v1/resources/categories/{resourcesCategoryId}")]
        public IActionResult DeleteResourceCategory([FromRoute] int resourcesCategoryId, [FromBody] DeleteResourcesCategoryRequest request)
        {
            return StatusCode(204);
        }
    }
}