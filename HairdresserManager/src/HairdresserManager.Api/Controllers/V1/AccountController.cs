using HairdresserManager.Shared.Contract.V1.Account.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserManager.Api.Controllers.V1
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost("api/v1/account/change-password")]
        public IActionResult ChangePassword([FromBody] ChangePasswordRequest request)
        {
            return NoContent();
        }

        [HttpPatch("api/v1/account")]
        public IActionResult UpdateAccount([FromBody] UpdateAccountRequest request)
        {
            return NoContent();
        }
    }
}