using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Contract.V1.TeamMembers.Responses;
using ApplicationCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1.Offer
{
    public class TeamMembersController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public TeamMembersController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet("api/v1/team-members")]
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
    }
}