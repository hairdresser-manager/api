using System.Threading.Tasks;
using ApplicationCore.Contract.V1;
using ApplicationCore.Contract.V1.General.Responses;
using ApplicationCore.Contract.V1.User.Account.Requests;
using ApplicationCore.Contract.V1.User.Account.Responses;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;

namespace WebApi.Controllers.V1.User
{
    [Authorize]
    [ApiController]
    [ApiExplorerSettings(GroupName = "User / Account")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public AccountController(IUserService userService, IIdentityService identityService, IMapper mapper)
        {
            _userService = userService;
            _identityService = identityService;
            _mapper = mapper;
        }

        [HttpPost(ApiRoutes.Account.ChangePassword)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var result = await _identityService.ChangePasswordAsync(HttpContext.GetUserId(), request.CurrentPassword,
                request.NewPassword);
            return result.Succeeded ? NoContent() : BadRequest(new ErrorResponse(result.Errors));
        }

        [HttpPut(ApiRoutes.Account.EditUserData)]
        public async Task<IActionResult> UpdateAccount([FromBody] UpdateAccountRequest request)
        {
            var userDto = _mapper.Map<UserDto>(request);
            await _userService.UpdateUserDataAsync(HttpContext.GetUserId(), userDto);
            return NoContent();
        }

        [HttpGet(ApiRoutes.Account.GetUserData)]
        public async Task<IActionResult> GetUserData()
        { 
            var userDto = await _userService.GetUserDtoByIdAsync(HttpContext.GetUserId());
            var response = _mapper.Map<GetUserDataResponse>(userDto);
            return Ok(response);
        }
    }
}