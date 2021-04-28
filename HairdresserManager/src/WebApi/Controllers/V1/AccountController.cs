using System;
using System.Threading.Tasks;
using ApplicationCore.Contract.V1;
using ApplicationCore.Contract.V1.Account.Requests;
using ApplicationCore.Contract.V1.General.Responses;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;

namespace WebApi.Controllers.V1
{
    [Authorize]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IIdentityService _identityService;

        public AccountController(IUserService userService, IIdentityService identityService)
        {
            _userService = userService;
            _identityService = identityService;
        }

        [HttpPost(ApiRoutes.Account.ChangePassword)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var result = await _identityService.ChangePasswordAsync(HttpContext.GetUserId(), request.CurrentPassword,
                request.NewPassword);
            return result.Succeeded ? NoContent() : BadRequest(ErrorResponse.New(result.Errors));
        }

        [HttpPut(ApiRoutes.Account.EditUserData)]
        public async Task<IActionResult> UpdateAccount([FromBody] UpdateAccountRequest request)
        {
            var userDto = new UserDTO
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                MobilePhone = request.MobilePhone
            };

            await _userService.UpdateUserDataAsync(HttpContext.GetUserId(), userDto);
            return NoContent();
        }

        [HttpGet(ApiRoutes.Account.GetUserData)]
        public async Task<IActionResult> GetUserData()
        {
            var userDto = await _userService.GetUserDtoByIdAsync(HttpContext.GetUserId());
            return Ok(userDto);
        }
    }
}