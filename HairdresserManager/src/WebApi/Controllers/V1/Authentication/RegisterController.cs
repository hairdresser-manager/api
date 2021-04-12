using ApplicationCore.Contract.V1;
using ApplicationCore.Contract.V1.Register.Requests;
using ApplicationCore.Contract.V1.Register.Responses;
using ApplicationCore.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1.Authentication
{
    [ApiController]
    public class RegisterController : ControllerBase
    {
        [HttpPost(ApiRoutes.Register.RegisterUser)]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            var response = new RegisterResponse {ConfirmEmailUri = "/api/v1/register/verify-email/JzdWIiOiI"};
            var result = new ServiceResult<RegisterResponse> {Success = true, Data = response};
            return Ok(result.Data);
        }

        [HttpGet(ApiRoutes.Register.VerifyEmail)]
        public IActionResult VerifyEmail()
        {
            return NoContent();
        }
    }
}