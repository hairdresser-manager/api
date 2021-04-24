using System.Collections.Generic;
using ApplicationCore.Contract.V1.Appointment.Requests;
using ApplicationCore.Contract.V1.Appointment.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        [HttpGet("api/v1/appointments")]
        public IActionResult GetAppointments()
        {
            var response = new List<GetAppointmentResponse>
            {
                new()
                {
                    AppointmentId = 1, Date = "05.01.2020", Hour = "09:00", EmployeeName = "Bartosh",
                    EmployeeLowQualityAvatar =
                        "https://images.chesscomfiles.com/uploads/v1/master_player/e4a20096-88e9-11eb-94e3-39aa30591f7c.1fdbd8e5.250x250o.1413e8d0bb72.jpeg",
                    ServiceName = "Hair cutting", Rated = false
                },
                new()
                {
                    AppointmentId = 2, Date = "04.12.2019", Hour = "19:15", EmployeeName = "Bart",
                    EmployeeLowQualityAvatar =
                        "https://images.chesscomfiles.com/uploads/v1/master_player/e4a20096-88e9-11eb-94e3-39aa30591f7c.1fdbd8e5.250x250o.1413e8d0bb72.jpeg",
                    ServiceName = "Hair colored", Rated = false
                },
                new()
                {
                    AppointmentId = 3, Date = "10.11.2021", Hour = "11:30", EmployeeName = "Osh",
                    EmployeeLowQualityAvatar =
                        "https://images.chesscomfiles.com/uploads/v1/master_player/e4a20096-88e9-11eb-94e3-39aa30591f7c.1fdbd8e5.250x250o.1413e8d0bb72.jpeg",
                    ServiceName = "Beard cutting", Rated = true
                }
            };


            return Ok(response);
        }

        [HttpPost("api/v1/appointments")]
        public IActionResult CreateAppointmentRequest([FromBody] CreateAppointmentRequest request)
        {
            return NoContent();
        }

        [HttpDelete("api/v1/appointments/{appointmentId}")]
        public IActionResult DeleteAppointment([FromRoute] int appointmentId)
        {
            return NoContent();
        }
        
        [HttpGet("api/v1/appointments/available-dates")]
        public IActionResult GetFreeAppointmentsV2()
        {
            var response = ScheduleResponseFakeData.GetData();
            return Ok(response);
        }
    }
}