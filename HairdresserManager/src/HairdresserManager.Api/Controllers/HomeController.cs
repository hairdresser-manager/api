using Microsoft.AspNetCore.Mvc;
using HairdresserManager.Shared;

namespace HairdresserManager.Api.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("v1/shared")]
        public IActionResult Shared()
        {
            return Content(Class1.GetSharedString());
        }
    }
}