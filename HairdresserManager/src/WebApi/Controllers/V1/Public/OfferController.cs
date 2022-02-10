using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contract.V1.Offer;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1.Public
{
    [ApiController]
    [Route("api/v1/offers")]
    [ApiExplorerSettings(GroupName = "Public / Offer")]
    public class OfferController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IServiceService _serviceService;
        private readonly IServiceCategoryService _serviceCategoryService;
        private readonly IMapper _mapper;

        public OfferController(IEmployeeService employeeService, IMapper mapper,
            IServiceCategoryService serviceCategoryService, IServiceService serviceService)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _serviceCategoryService = serviceCategoryService;
            _serviceService = serviceService;
        }

        [HttpGet("team-members")]
        public async Task<IActionResult> GetTeamMembers()
        {
            var employeesDto = await _employeeService.GetEmployeesDtoAsync();
            var response = new List<GetTeamMemberResponse>();

            foreach (var employee in employeesDto)
            {
                if (employee.Active)
                    response.Add(_mapper.Map<GetTeamMemberResponse>(employee));
            }

            return Ok(response);
        }

        [HttpGet("services")]
        public async Task<IActionResult> GetServices()
        {
            var servicesDto = await _serviceService.GetServicesDtoAsync();
            var serviceCategoriesDto =
                (List<ServicesCategoryDto>) await _serviceCategoryService.GetServicesCategoriesDtoAsync();

            if (servicesDto == null)
                return NotFound();

            var response = new List<GetServiceResponse>();

            foreach (var serviceDto in servicesDto)
            {
                if (!serviceDto.Available || serviceDto.EmployeeIds == null)
                    continue;

                var serviceCategoryName = serviceCategoriesDto.FirstOrDefault(s => s.Id == serviceDto.CategoryId)?.Name;

                var serviceResponse = response.SingleOrDefault(r => r.CategoryName.Equals(serviceCategoryName));

                if (serviceResponse == null)
                {
                    response.Add(new GetServiceResponse
                    {
                        CategoryName = serviceCategoryName, Services = new List<ServiceDto> {serviceDto}
                    });
                }
                else
                {
                    serviceResponse.Services.Add(serviceDto);
                }
            }
            
            return Ok(response);
        }
    }
}