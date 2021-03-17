using System.Threading.Tasks;
using HairdresserManager.Shared.Contract.V1;
using HairdresserManager.Shared.Contract.V1.GeneralResponses;
using HairdresserManager.Shared.Contract.V1.Login.Requests;
using HairdresserManager.Shared.Contract.V1.Login.Responses;
using HairdresserManager.Shared.Results;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserManager.Api.Controllers.V1
{
    [ApiController]
    public class LoginController : MainController
    {
        [HttpPost(ApiRoutes.Login.LoginUser)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = new JwtTokensResponse
            {
                AccessToken =
                    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c",
                RefreshToken = "UGeKMA6L8YwCyY2uuoi8Iz1wrJmCcT"
            };
            var result = new ServiceResult<JwtTokensResponse> {Success = true, Data = response};
            return GenerateResponse(result);
        }

        [HttpPost(ApiRoutes.Login.FacebookAuth)]
        public async Task<IActionResult> FacebookAuth([FromBody] FacebookAuthRequest request)
        {
            var response = new JwtTokensResponse
            {
                AccessToken =
                    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c",
                RefreshToken = "UGeKMA6L8YwCyY2uuoi8Iz1wrJmCcT"
            };
            var result = new ServiceResult<JwtTokensResponse> {Success = true, Data = response};
            return GenerateResponse(result);
        }

        [HttpPost(ApiRoutes.Login.Logout)]
        public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
        {
            var result = new ServiceResult<NoContentResponse> {Success = true};
            return GenerateResponse(result);
        }
    }
}