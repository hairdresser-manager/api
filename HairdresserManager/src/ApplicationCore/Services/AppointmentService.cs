using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IHairdresserDbContext _context;

        public AppointmentService(IHairdresserDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<FreeDateDto>> GetFreeDatesAsync(ICollection<int> employeeIds,
            DateTime startDateUtc, DateTime endDateUtc, int serviceDuration)
        {
            var freeDates = new List<FreeDateDto>();

            foreach (var employeeId in employeeIds)
            {
                var schedules = await _context.Schedules
                    .Where(schedule => schedule.EmployeeId == employeeId
                                       && schedule.Date >= startDateUtc
                                       && schedule.Date < endDateUtc.AddDays(1))
                    .OrderBy(schedule => schedule.Date)
                    .AsNoTracking()
                    .ToListAsync();

                if (!schedules.Any())
                {
                    freeDates.Add(new FreeDateDto
                    {
                        EmployeeId = employeeId,
                        DateHoursDto = null
                    });

                    continue;
                }

                var datesHours = new List<DateHoursDto>();

                var employeeAppointments = await _context.Appointments
                    .Include(appointment => appointment.Service)
                    .Where(appointment =>
                        appointment.EmployeeId == employeeId
                        && appointment.DateUtc >= startDateUtc
                        && appointment.DateUtc < endDateUtc.AddDays(1))
                    .OrderBy(appointment => appointment.DateUtc)
                    .AsNoTracking()
                    .ToListAsync();

                foreach (var schedule in schedules)
                {
                    var appointments = employeeAppointments
                        .Where(appointment => appointment.DateUtc.Date == schedule.Date.Date)
                        .ToList();

                    if (appointments.Any())
                    {
                        var dateHours = GenerateDateHours(schedule, appointments, serviceDuration);
                        datesHours.Add(dateHours);
                    }
                    else
                    {
                        var dateHours = GenerateDateHours(schedule, serviceDuration);
                        datesHours.Add(dateHours);
                    }
                }

                freeDates.Add(new FreeDateDto
                {
                    EmployeeId = employeeId,
                    DateHoursDto = datesHours
                });
            }

            return freeDates;
        }

        private static DateHoursDto GenerateDateHours(Schedule schedule, int serviceDuration)
        {
            var dateHours = new DateHoursDto
            {
                Date = schedule.Date
            };

            var startingHour = schedule.StartingHour;

            if (schedule.Date == DateTime.Today)
            {
                var currentUtcHour = DateTime.UtcNow.ToString("HH:mm");
                var roundedUtcHour = TimeHelper.RoundUpToQuarter(currentUtcHour);
                startingHour = TimeHelper.AddMinutes(roundedUtcHour, 30);
            }

            var hours = new List<string> {startingHour};

            var hour = TimeHelper.AddMinutes(startingHour, 15);
            var lastPossibleHour = TimeHelper.RemoveMinutes(schedule.EndingHour, serviceDuration);

            while (TimeHelper.IsLessOrEqualThan(hour, lastPossibleHour))
            {
                hours.Add(hour);
                hour = TimeHelper.AddMinutes(hours.Last(), 15);
            }

            dateHours.Hours = hours;

            return dateHours;
        }

        private static DateHoursDto GenerateDateHours(Schedule schedule, IEnumerable<Appointment> appointments,
            int serviceDuration)
        {
            var dateHours = new DateHoursDto
            {
                Date = schedule.Date,
                Hours = GetHoursList(schedule.Date, schedule.StartingHour, schedule.EndingHour)
            };

            var newHoursTemp = dateHours.Hours.ToList();

            foreach (var appointment in appointments)
            {
                var appointmentDuration = appointment.Service.MaximumTime;
                var hourToRemove = appointment.DateUtc.ToString("HH:mm");

                var appointmentEndHour = TimeHelper.AddMinutes(hourToRemove, appointmentDuration);

                while (TimeHelper.IsLessThan(hourToRemove, appointmentEndHour))
                {
                    var indexToRemove = newHoursTemp.IndexOf(hourToRemove);

                    if (indexToRemove != -1)
                        newHoursTemp.RemoveAt(indexToRemove);

                    hourToRemove = TimeHelper.AddMinutes(hourToRemove, 15);
                }
            }

            var newHours = new List<string>();

            foreach (var hour in newHoursTemp)
            {
                var nextHoursToCheck = serviceDuration / 15;
                var validHour = true;
                var nextHour = TimeHelper.AddMinutes(hour, 15);

                while (nextHoursToCheck > 1)
                {
                    var indexOfNextHour = newHoursTemp.IndexOf(nextHour);

                    if (indexOfNextHour == -1)
                    {
                        validHour = false;
                        break;
                    }

                    nextHour = TimeHelper.AddMinutes(nextHour, 15);
                    nextHoursToCheck--;
                }

                if (TimeHelper.IsGreaterThan(nextHour, schedule.EndingHour))
                    validHour = false;

                if (validHour)
                    newHours.Add(hour);
            }

            dateHours.Hours = newHours;

            return dateHours;
        }

        private static List<string> GetHoursList(DateTime date, string startingHour, string endingHour)
        {
            if (date == DateTime.Today)
            {
                var currentUtcHour = DateTime.UtcNow.ToString("HH:mm");
                var roundedUtcHour = TimeHelper.RoundUpToQuarter(currentUtcHour);
                startingHour = TimeHelper.AddMinutes(roundedUtcHour, 30);
            }

            var hours = new List<string> {startingHour};

            var hour = TimeHelper.AddMinutes(startingHour, 15);

            while (TimeHelper.IsLessOrEqualThan(hour, endingHour))
            {
                hours.Add(hour);
                hour = TimeHelper.AddMinutes(hours.Last(), 15);
            }

            return hours;
        }
    }
}