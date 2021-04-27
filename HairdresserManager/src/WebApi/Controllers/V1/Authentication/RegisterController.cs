using System.Threading.Tasks;
using ApplicationCore.Contract.V1;
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
        
        public RegisterController(IUserService userService, IClientService clientService)
        {
            _userService = userService;
            _clientService = clientService;
        }
        
        [HttpPost(ApiRoutes.Register.RegisterUser)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (await _userService.UserExistsByEmailAsync(request.Email))
                return BadRequest("User already exists");
            
            var (result, userId, verifyToken) = await _userService.CreateUserAsync(request);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            var added = await _clientService.AddUserToClientAsync(userId);
            var url = $"verify-email?token={verifyToken}&email={request.Email}";
            
            return added ? Ok(url) : BadRequest("Something went wrong");
        }

        [HttpGet(ApiRoutes.Register.VerifyEmail)]
        public async Task<IActionResult> VerifyEmail([FromQuery] string token, string email)
        {
            var result = await _userService.VerifyEmailAsync(email, token);

            if (result.Succeeded)
                return NoContent();
            
            return BadRequest(result.Errors);
        }
    }
}