using Microsoft.AspNetCore.Mvc;

namespace HairdresserManager.Api.Controllers.V1
{
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        [HttpGet("api/v1/schedules")]
        public IActionResult GetSchedule()
        {
            return Ok();
        }
    }
}