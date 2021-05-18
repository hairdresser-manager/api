using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using ApplicationCore.Validations;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IEmployeeService _employeeService;
        private readonly IScheduleService _scheduleService;
        private readonly IHairdresserDbContext _context;

        public AppointmentService(IScheduleService scheduleService, IEmployeeService employeeService,
            IHairdresserDbContext context)
        {
            _scheduleService = scheduleService;
            _employeeService = employeeService;
            _context = context;
        }

        public async Task<List<(string, List<string>)>> GetFreeFutureDatesForEmployeeAsync(int employeeId)
        {
            //TODO: this code is only for demo purposes 
            var schedulesDto = await _scheduleService.GetSchedulesDtoByEmployeeIdAsync(employeeId);

            if (schedulesDto == null)
                return null;

            var freeDates = new List<(string, List<string>)>();

            foreach (var scheduleDto in schedulesDto)
            {
                var hours = new List<string> {scheduleDto.StartingHour};
                
                var hour = TimeHelper.AddMinutes(hours.Last(), 15);
                do
                {
                    hours.Add(hour);
                    hour = TimeHelper.AddMinutes(hours.Last(), 15);
                } while (TimeHelper.IsLessThan(hour, scheduleDto.EndingHour));

                freeDates.Add((scheduleDto.Date, hours));
            }

            return freeDates;
        }

        private async Task<IEnumerable<Appointment>> GetEmployeeFutureAppointments(int employeeId) =>
            await _context.Appointments
                .Where(a => a.EmployeeId == employeeId && a.Date >= DateTime.Today)
                .ToListAsync();
    }
}