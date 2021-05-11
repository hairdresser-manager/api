using System.Threading.Tasks;
using ApplicationCore.Contract.V1.General.Responses;
using ApplicationCore.Contract.V1.Service.Requests;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1.Offer
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceCategoryService _serviceCategoryService;
        private readonly IServiceService _serviceService;
        private readonly IMapper _mapper;

        public ServiceController(IServiceService serviceService, IMapper mapper,
            IServiceCategoryService serviceCategoryService)
        {
            _serviceService = serviceService;
            _mapper = mapper;
            _serviceCategoryService = serviceCategoryService;
        }

        [HttpGet("api/v1/services")]
        public async Task<IActionResult> GetServices()
        {
            var servicesDto = await _serviceService.GetServicesDtoAsync();
            return servicesDto != null ? Ok(servicesDto) : NotFound();
        }

        [HttpPost("api/v1/services")]
        public async Task<IActionResult> CreateService([FromBody] CreateServiceRequest request)
        {
            var serviceDto = await _serviceService.GetServiceDtoByNameAsync(request.Name);

            if (serviceDto != null)
                return BadRequest(new ErrorResponse("Service with this name already exists"));

            if (await _serviceCategoryService.GetServicesCategoryDtoByIdAsync(request.CategoryId) == null)
                return BadRequest(new ErrorResponse("Category doesn't exist"));

            var serviceToCreateDto = _mapper.Map<ServiceDto>(request);

            var result = await _serviceService.CreateServiceAsync(serviceToCreateDto);
            return result.Succeeded ? NoContent() : BadRequest(new ErrorResponse(result.Errors));
        }

        [HttpPut("api/v1/services/{serviceId}")]
        public async Task<IActionResult> UpdateService([FromRoute] int serviceId,
            [FromBody] UpdateServiceRequest request)
        {
            var serviceDto = await _serviceService.GetServiceDtoByNameAsync(request.Name);

            if (serviceDto != null)
                if (serviceDto.Id != serviceId)
                    return BadRequest(new ErrorResponse("Service with this name already exists"));

            if (await _serviceCategoryService.GetServicesCategoryDtoByIdAsync(request.CategoryId) == null)
                return BadRequest(new ErrorResponse("Category doesn't exist"));

            var serviceToUpdateDto = _mapper.Map<ServiceDto>(request);
            serviceToUpdateDto.Id = serviceId;
            var result = await _serviceService.UpdateServiceAsync(serviceToUpdateDto);

            return result.Succeeded ? NoContent() : BadRequest(new ErrorResponse(result.Errors));
        }
    }
}