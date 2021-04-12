using HairdresserManager.Shared.Contract.V1;
using HairdresserManager.Shared.Contract.V1.General.Responses;
using HairdresserManager.Shared.Contract.V1.Login.Requests;
using HairdresserManager.Shared.Contract.V1.Login.Responses;
using HairdresserManager.Shared.Results;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserManager.Api.Controllers.V1.Authentication
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost(ApiRoutes.Login.LoginUser)]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var response = new JwtTokensResponse
            {
                AccessToken =
                    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c",
                RefreshToken = "UGeKMA6L8YwCyY2uuoi8Iz1wrJmCcT"
            };
            var result = new ServiceResult<JwtTokensResponse> {Success = true, Data = response};
            return Ok(result.Data);
        }

        [HttpPost(ApiRoutes.Login.FacebookAuth)]
        public IActionResult FacebookAuth([FromBody] FacebookAuthRequest request)
        {
            var response = new JwtTokensResponse
            {
                AccessToken =
                    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c",
                RefreshToken = "UGeKMA6L8YwCyY2uuoi8Iz1wrJmCcT"
            };
            var result = new ServiceResult<JwtTokensResponse> {Success = true, Data = response};
            return Ok(result.Data);
        }

        [HttpPost(ApiRoutes.Login.Logout)]
        public IActionResult Logout([FromBody] LogoutRequest request)
        {
            return NoContent();
        }
    }
}