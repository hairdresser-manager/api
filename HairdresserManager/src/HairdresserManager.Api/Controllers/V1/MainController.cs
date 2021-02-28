using HairdresserManager.Shared.Results;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserManager.Api.Controllers.V1
{
    public abstract class MainController : ControllerBase
    {
        private IActionResult GenerateResponse<T>(ServiceResult<T> result)
            => StatusCode(result.ResponseCode, result.Success ? result.Data : result.Errors);
    }
}