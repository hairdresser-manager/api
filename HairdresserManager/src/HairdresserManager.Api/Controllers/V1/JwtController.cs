using System.Threading.Tasks;
using HairdresserManager.Shared.Contract.V1;
using HairdresserManager.Shared.Contract.V1.Jwt.Requests;
using HairdresserManager.Shared.Contract.V1.Jwt.Responses;
using HairdresserManager.Shared.Results;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserManager.Api.Controllers.V1
{
    [ApiController]
    public class JwtController : MainController
    {
        [HttpPost(ApiRoutes.RefreshToken.Refresh)]
        public async Task<IActionResult> RefreshToken([FromBody] JwtRefreshRequest request)
        {
            var response = new JwtRefreshResponse
            {
                AccessToken =
                    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c",
                RefreshToken = "UGeKMA6L8YwCyY2uuoi8Iz1wrJmCcT"
            };
            
            var result = new ServiceResult<JwtRefreshResponse> {Success = true, Data = response};
            return GenerateResponse(result);
        }
    }
}