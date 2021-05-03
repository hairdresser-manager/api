using System.Threading.Tasks;
using ApplicationCore.Contract.V1;
using ApplicationCore.Contract.V1.General.Responses;
using ApplicationCore.Contract.V1.Login.Requests;
using ApplicationCore.Contract.V1.Login.Responses;
using ApplicationCore.Interfaces;
using ApplicationCore.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1.Authentication
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;
        private readonly IIdentityService _identityService;

        public LoginController(IUserService userService, IJwtService jwtService, IIdentityService identityService)
        {
            _userService = userService;
            _jwtService = jwtService;
            _identityService = identityService;
        }

        [HttpPost(ApiRoutes.Login.LoginUser)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _identityService.GetUserDtoByCredentialsAsync(request.Email, request.Password);
            
            if (user == null)
                return BadRequest(new ErrorResponse("user doesn't exist or credentials are wrong"));

            if (!user.EmailConfirmed)
                return BadRequest(new ErrorResponse("email isn't verified"));

            var accessToken = _jwtService.GenerateAccessToken(user);
            
            var response = new LoginResponse
            {
                FirstName = user.FirstName,
                Email = user.Email,
                Role = user.Role,
                AccessToken = accessToken,
                RefreshToken = "not-implemented-yet",
            };
            
            return Ok(response);
        }

        [HttpPost(ApiRoutes.Login.FacebookAuth)]
        public IActionResult FacebookAuth([FromBody] FacebookAuthRequest request)
        {
            var fakeResponse = new LoginResponse
            {
                AccessToken =
                    "not-implemented-yet",
                RefreshToken = "not-implemented-yet"
            };
            
            var result = new ServiceResult<LoginResponse> {Success = true, Data = fakeResponse};
            return Ok(result.Data);
        }

        [HttpPost(ApiRoutes.Login.Logout)]
        public IActionResult Logout([FromBody] LogoutRequest request)
        {
            return NoContent();
        }
    }
}