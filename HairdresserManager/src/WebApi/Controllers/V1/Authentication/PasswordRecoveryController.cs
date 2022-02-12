using System;
using ApplicationCore.Contract.V1;
using ApplicationCore.Contract.V1.Authentication.PasswordRecovery.Requests;
using ApplicationCore.Contract.V1.Authentication.PasswordRecovery.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1.Authentication
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "Authentication / PasswordRecovery")]
    public class PasswordRecoveryController : ControllerBase
    {
        [HttpPost(ApiRoutes.PasswordRecovery.RemindPassword)]
        public IActionResult RemindPassword([FromBody] RemindPasswordRequest request)
        {
            var response = new RemindPasswordResponse {ResetPasswordKey = Guid.NewGuid().ToString()};
            
            return Ok(response);
        }

        [HttpPost(ApiRoutes.PasswordRecovery.ResetPassword)]
        public IActionResult ResetPassword([FromBody] ResetPasswordRequest request)
        {
            return NoContent();
        }
    }
}