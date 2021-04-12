using HairdresserManager.Shared.Contract.V1;
using HairdresserManager.Shared.Contract.V1.General.Responses;
using HairdresserManager.Shared.Contract.V1.Register.Requests;
using HairdresserManager.Shared.Contract.V1.Register.Responses;
using HairdresserManager.Shared.Results;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserManager.Api.Controllers.V1.Authentication
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