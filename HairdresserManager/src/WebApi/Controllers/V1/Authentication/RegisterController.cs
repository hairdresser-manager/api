using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Contract.V1;
using ApplicationCore.Contract.V1.General.Responses;
using ApplicationCore.Contract.V1.Register.Requests;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1.Authentication
{
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IClientService _clientService;
        private readonly IIdentityService _identity;

        public RegisterController(IUserService userService, IClientService clientService, IIdentityService identity)
        {
            _userService = userService;
            _clientService = clientService;
            _identity = identity;
        }

        [HttpPost(ApiRoutes.Register.RegisterUser)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (await _userService.UserExistsByEmailAsync(request.Email))
                return BadRequest(ErrorResponse.New("user already exists"));

            var (result, userId, verifyToken) = await _userService.CreateUserAsync(request);

            if (!result.Succeeded)
                return BadRequest(ErrorResponse.New(result.Errors));

            var added = await _clientService.AddUserToClientAsync(userId);
            var url = $"verify-email?token={verifyToken}&email={request.Email}";

            return added ? Ok(url) : BadRequest(ErrorResponse.New("Something went wrong"));
        }

        [HttpGet(ApiRoutes.Register.VerifyEmail)]
        public async Task<IActionResult> VerifyEmail([FromQuery] string email, string token)
        {
            var result = await _identity.VerifyEmailAsync(email, token);
            return result.Succeeded ? NoContent() : BadRequest(ErrorResponse.New(result.Errors));
        }
    }
}