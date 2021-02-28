using System;
using HairdresserManager.Shared.Contract.Auth.Requests;
using HairdresserManager.Shared.Contract.Auth.Responses;
using HairdresserManager.Shared.Contract.V1;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserManager.Api.Controllers.V1
{
    [ApiController]
    public class AuthController : MainController
    {
        [HttpPost(ApiRoutes.Auth.Login)]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            return Ok();
        }
        
        [HttpPost(ApiRoutes.Auth.Logout)]
        public IActionResult Logout([FromBody] LogoutRequest request)
        {
            return Ok();
        }

        [HttpPost(ApiRoutes.Auth.Register)]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            return Ok(new RegisterResponse());
        }
        
        [HttpPost(ApiRoutes.Auth.FacebookAuth)]
        public IActionResult FacebookAuth([FromBody] FacebookAuthRequest request)
        {
            const string accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";
            var refreshToken = Guid.NewGuid();
            var response = new FacebookAuthResponse {AccessToken = accessToken, RefreshToken = refreshToken};
            return Ok(response);
        }
        
        [HttpPost(ApiRoutes.Auth.RefreshToken)]
        public IActionResult RefreshToken([FromBody] RefreshTokenRequest request)
        {
            return Ok();
        }

        [HttpPost(ApiRoutes.Auth.RemindPassword)]
        public IActionResult RemindPassword([FromBody] RemindPasswordRequest request)
        {
            return Ok();
        }

        [HttpPost(ApiRoutes.Auth.ResetPassword)]
        public IActionResult ResetPassword([FromBody] ResetPasswordRequest request)
        {
            return Ok();
        }

        [HttpGet(ApiRoutes.Auth.VerifyEmail)]
        public IActionResult VerifyEmail()
        {
            return Ok();
        }
    }
}