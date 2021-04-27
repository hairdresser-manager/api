using System.Threading.Tasks;
using ApplicationCore.Contract.V1;
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

        public LoginController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost(ApiRoutes.Login.LoginUser)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userService.GetUserDtoByCredentialsAsync(request.Email, request.Password);
            
            if (user == null)
                return BadRequest("User doesn't exists or credentials are wrong");

            var accessToken = _jwtService.GenerateAccessToken(user);
            
            var response = new LoginResponse
            {
                FirstName = user.FirstName,
                Email = user.Email,
                Role = user.Role,
                AccessToken = accessToken,
                RefreshToken = "not-implemented-yet"
            };
            
            return Ok(response);
        }

        [HttpPost(ApiRoutes.Login.FacebookAuth)]
        public IActionResult FacebookAuth([FromBody] FacebookAuthRequest request)
        {
            var response = new LoginResponse
            {
                AccessToken =
                    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c",
                RefreshToken = "UGeKMA6L8YwCyY2uuoi8Iz1wrJmCcT"
            };
            var result = new ServiceResult<LoginResponse> {Success = true, Data = response};
            return Ok(result.Data);
        }

        [HttpPost(ApiRoutes.Login.Logout)]
        public IActionResult Logout([FromBody] LogoutRequest request)
        {
            return NoContent();
        }
    }
}