using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1.Employee
{
    [ApiController]
    [Route("api/v1/employees/appointments")]
    [ApiExplorerSettings(GroupName = "Employee / Appointments")]
    public class AppointmentController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAppointments()
        {
            return Ok();
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAppointment()
        {
            return Ok();
        }
    }
}