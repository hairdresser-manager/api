using System;
using System.Threading.Tasks;
using HairdresserManager.Shared.Contract.V1;
using HairdresserManager.Shared.Contract.V1.General.Responses;
using HairdresserManager.Shared.Contract.V1.PasswordRecovery.Requests;
using HairdresserManager.Shared.Contract.V1.PasswordRecovery.Responses;
using HairdresserManager.Shared.Results;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserManager.Api.Controllers.V1
{
    [ApiController]
    public class PasswordRecoveryController : MainController
    {
        [HttpPost(ApiRoutes.PasswordRecovery.RemindPassword)]
        public IActionResult RemindPassword([FromBody] RemindPasswordRequest request)
        {
            var result = new ServiceResult<RemindPasswordResponse> {Success = true, ResponseCode = 200};
            result.Data = new RemindPasswordResponse {ResetPasswordKey = Guid.NewGuid().ToString()};
            
            return GenerateResponse(result);
        }

        [HttpPost(ApiRoutes.PasswordRecovery.ResetPassword)]
        public IActionResult ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var result = new ServiceResult<NoContentResponse> {Success = true, ResponseCode = 204};
            return GenerateResponse(result);
        }
    }
}