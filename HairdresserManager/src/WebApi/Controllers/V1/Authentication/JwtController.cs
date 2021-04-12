using ApplicationCore.Contract.V1;
using ApplicationCore.Contract.V1.Jwt.Requests;
using ApplicationCore.Contract.V1.Jwt.Responses;
using ApplicationCore.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1.Authentication
{
    [ApiController]
    public class JwtController : ControllerBase
    {
        [HttpPost(ApiRoutes.RefreshToken.Refresh)]
        public IActionResult RefreshToken([FromBody] JwtRefreshRequest request)
        {
            var response = new JwtRefreshResponse
            {
                AccessToken =
                    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c",
                RefreshToken = "UGeKMA6L8YwCyY2uuoi8Iz1wrJmCcT"
            };
            
            var result = new ServiceResult<JwtRefreshResponse> {Success = true, Data = response};
            return Ok(result.Data);
        }
    }
}