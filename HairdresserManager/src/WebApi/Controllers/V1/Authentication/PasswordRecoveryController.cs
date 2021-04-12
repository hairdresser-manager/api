using System;
using ApplicationCore.Contract.V1;
using ApplicationCore.Contract.V1.PasswordRecovery.Requests;
using ApplicationCore.Contract.V1.PasswordRecovery.Responses;
using ApplicationCore.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1.Authentication
{
    [ApiController]
    public class PasswordRecoveryController : ControllerBase
    {
        [HttpPost(ApiRoutes.PasswordRecovery.RemindPassword)]
        public IActionResult RemindPassword([FromBody] RemindPasswordRequest request)
        {
            var result = new ServiceResult<RemindPasswordResponse> {Success = true};
            result.Data = new RemindPasswordResponse {ResetPasswordKey = Guid.NewGuid().ToString()};
            
            return Ok(result.Data);
        }

        [HttpPost(ApiRoutes.PasswordRecovery.ResetPassword)]
        public IActionResult ResetPassword([FromBody] ResetPasswordRequest request)
        {
            return NoContent();
        }
    }
}