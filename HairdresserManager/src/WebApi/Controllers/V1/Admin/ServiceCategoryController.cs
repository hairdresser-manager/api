using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contract.V1.Admin.ServiceCategory;
using ApplicationCore.Contract.V1.General.Responses;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1.Admin
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Route("api/v1/services/categories")]
    [ApiExplorerSettings(GroupName = "Admin / Services")]
    public class ServiceCategoryController : ControllerBase
    {
        private readonly IServiceCategoryService _serviceCategoryService;

        public ServiceCategoryController(IServiceCategoryService serviceCategoryService)
        {
            _serviceCategoryService = serviceCategoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateServiceCategoryRequest request)
        {
            var result = await _serviceCategoryService.CreateCategoryAsync(request.Name);
            return result.Succeeded ? NoContent() : BadRequest(new ErrorResponse(result.Errors));
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var servicesCategoriesDto = await _serviceCategoryService.GetServicesCategoriesDtoAsync();
            return servicesCategoriesDto.Any() ? Ok(servicesCategoriesDto) : NotFound();
        }

        [HttpPut("{categoryId:int}")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateServicesCategoryRequest request,
            [FromRoute] int categoryId)
        {
            var servicesCategoryDto = await _serviceCategoryService.GetServicesCategoryDtoByIdAsync(categoryId);

            if (servicesCategoryDto == null)
                return BadRequest(new ErrorResponse("Services category doesn't exist"));

            var result = await _serviceCategoryService.UpdateServicesCategoryAsync(categoryId, request.Name);

            return result.Succeeded ? NoContent() : BadRequest(new ErrorResponse(result.Errors));
        }
    }
}