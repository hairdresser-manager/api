using System.Threading.Tasks;
using HairdresserManager.Api.Services.Interfaces;
using HairdresserManager.Shared.Contract.V1;
using HairdresserManager.Shared.Contract.V1.Auth.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserManager.Api.Controllers.V1
{
    [ApiController]
    public class AuthController : MainController
    {
        private readonly IAuthService _authService;
        
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        
        [HttpPost(ApiRoutes.Auth.Login)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _authService.LoginAsync();
            return GenerateResponse(result);
        }
        
        [HttpPost(ApiRoutes.Auth.Logout)]
        public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
        {
            var result = await _authService.LogoutAsync();
            return GenerateResponse(result);
        }

        [HttpPost(ApiRoutes.Auth.Register)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _authService.RegisterAsync();
            return GenerateResponse(result);
        }
        
        [HttpPost(ApiRoutes.Auth.FacebookAuth)]
        public async Task<IActionResult> FacebookAuth([FromBody] FacebookAuthRequest request)
        {
            var result = await _authService.FacebookAuthAsync();
            return GenerateResponse(result);
        }
        
        [HttpPost(ApiRoutes.Auth.RefreshToken)]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            var result = await _authService.RefreshTokenAsync();
            return GenerateResponse(result);
        }

        [HttpPost(ApiRoutes.Auth.RemindPassword)]
        public async Task<IActionResult> RemindPassword([FromBody] RemindPasswordRequest request)
        {
            var result = await _authService.RemindPasswordAsync();
            return GenerateResponse(result);
        }

        [HttpPost(ApiRoutes.Auth.ResetPassword)]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var result = await _authService.ResetPasswordAsync();
            return GenerateResponse(result);
        }

        [HttpGet(ApiRoutes.Auth.VerifyEmail)]
        public async Task<IActionResult> VerifyEmail()
        {
            var result = await _authService.VerifyEmailAsync();
            return GenerateResponse(result);
        }
    }
}