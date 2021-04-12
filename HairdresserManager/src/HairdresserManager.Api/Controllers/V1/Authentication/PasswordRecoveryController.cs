using System;
using HairdresserManager.Shared.Contract.V1;
using HairdresserManager.Shared.Contract.V1.General.Responses;
using HairdresserManager.Shared.Contract.V1.PasswordRecovery.Requests;
using HairdresserManager.Shared.Contract.V1.PasswordRecovery.Responses;
using HairdresserManager.Shared.Results;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserManager.Api.Controllers.V1.Authentication
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