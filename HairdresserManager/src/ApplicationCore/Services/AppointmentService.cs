using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using ApplicationCore.Results;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IHairdresserDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public AppointmentService(IHairdresserDbContext context, IMapper mapper, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<ICollection<FreeDateDto>> GetFreeDatesAsync(IEnumerable<int> employeeIds,
            DateTime startDate, DateTime endDate, int serviceDuration)
        {
            var freeDates = new List<FreeDateDto>();

            foreach (var employeeId in employeeIds)
            {
                var schedules = await _context.Schedules
                    .Where(schedule => schedule.EmployeeId == employeeId
                                       && schedule.Date >= startDate
                                       && schedule.Date < endDate.AddDays(1))
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
                        && appointment.Canceled == false
                        && appointment.Date >= startDate
                        && appointment.Date < endDate.AddDays(1))
                    .OrderBy(appointment => appointment.Date)
                    .AsNoTracking()
                    .ToListAsync();

                foreach (var schedule in schedules)
                {
                    var appointments = employeeAppointments
                        .Where(appointment => appointment.Date.Date == schedule.Date.Date)
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

        public async Task<ServiceResult> CreateAppointmentAsync(AppointmentDto appointmentDto)
        {
            var service =
                await _context.Services
                    .AsNoTracking()
                    .SingleOrDefaultAsync(service => service.Id == appointmentDto.ServiceId);

            if (!await CanCreateAppointmentAsync(appointmentDto.EmployeeId, service.MaximumTime, appointmentDto.Date))
                return ServiceResult.Failure("Can't create appointment at " + appointmentDto.Date);

            var newAppointment = _mapper.Map<Appointment>(appointmentDto);

            await _context.Appointments.AddAsync(newAppointment);
            await _context.SaveChangesAsync(new CancellationToken());
            return ServiceResult.Success();
        }

        public async Task<IEnumerable<AppointmentEmployeeDetailsDto>> GetAppointmentDetailsDtosByUserIdAsync(
            Guid userId)
        {
            var user = await _userService.GetUserDtoByIdAsync(userId.ToString());
            var appointments = await _context.Appointments
                .Include(appointment => appointment.Employee)
                .Include(appointment => appointment.Review)
                .Include(appointment => appointment.Service)
                .Where(appointment => appointment.Client.UserId == userId || appointment.ClientEmail == user.Email)
                .ToListAsync();

            return appointments.Any() ? _mapper.Map<IEnumerable<AppointmentEmployeeDetailsDto>>(appointments) : null;
        }

        public async Task<ServiceResult> CancelUserAppointmentByIdAsync(Guid userId, int appointmentId)
        {
            var appointment = await _context.Appointments
                .Include(appointment => appointment.Client)
                .SingleOrDefaultAsync(appointment => appointment.Id == appointmentId);

            if (appointment == null)
                return ServiceResult.Failure("Appointment doesn't exist");

            if (appointment.Client.UserId != userId)
                return ServiceResult.Failure("You can't manipulate this appointment");

            if (appointment.Canceled)
                return ServiceResult.Failure("Appointment already canceled");

            if (appointment.Date >= DateTime.Now)
                return ServiceResult.Failure("You can't cancel past appointment");

            appointment.Canceled = true;
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync(new CancellationToken());
            return ServiceResult.Success();
        }

        public async Task<IEnumerable<AppointmentClientDetailsDto>> GetAppointmentDetailsDtosByEmployeeIdAsync(
            DateTime date, int employeeId)
        {
            var appointments = await _context.AppointmentClientDetailsView
                .Where(appointment => appointment.EmployeeId == employeeId && appointment.Date.Date == date.Date)
                .ToListAsync();

            return _mapper.Map<IEnumerable<AppointmentClientDetailsDto>>(appointments);
        }

        private async Task<bool> CanCreateAppointmentAsync(int employeeId, int duration, DateTime date)
        {
            var schedule = await _context.Schedules
                .FirstOrDefaultAsync(schedule => schedule.EmployeeId == employeeId && schedule.Date.Date == date.Date);

            if (schedule == null)
                return false;

            if (!(TimeHelper.IsGreaterOrEqualTo(date.ToString("HH:mm"), schedule.StartingHour) &&
                  TimeHelper.IsLessOrEqualTo(date.AddMinutes(duration).ToString("HH:mm"), schedule.EndingHour)))
                return false;

            var isAvailableDate = !await _context.Appointments.Where(appointment =>
                    appointment.EmployeeId == employeeId &&
                    appointment.Canceled == false &&
                    ((appointment.Date <= date &&
                      appointment.Date.AddMinutes(appointment.Service.MaximumTime) > date) ||
                     appointment.Date < date.AddMinutes(duration) &&
                     appointment.Date.AddMinutes(appointment.Service.MaximumTime) >= date.AddMinutes(duration)))
                .AnyAsync();

            return isAvailableDate;
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
                var currentHour = DateTime.Now.ToString("HH:mm");

                if (TimeHelper.IsGreaterOrEqualTo(currentHour, schedule.EndingHour))
                    return dateHours;

                var roundedHour = TimeHelper.RoundUpToQuarter(currentHour);
                startingHour = TimeHelper.AddMinutes(roundedHour, 30);
            }

            var hours = new List<string> {startingHour};

            var hour = TimeHelper.AddMinutes(startingHour, 15);
            var lastPossibleHour = TimeHelper.RemoveMinutes(schedule.EndingHour, serviceDuration);

            while (TimeHelper.IsLessOrEqualTo(hour, lastPossibleHour))
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
                var hourToRemove = appointment.Date.ToString("HH:mm");

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
                var currentHour = DateTime.Now.ToString("HH:mm");
                var roundedHour = TimeHelper.RoundUpToQuarter(currentHour);
                startingHour = TimeHelper.AddMinutes(roundedHour, 30);
            }

            var hours = new List<string> {startingHour};

            var hour = TimeHelper.AddMinutes(startingHour, 15);

            while (TimeHelper.IsLessOrEqualTo(hour, endingHour))
            {
                hours.Add(hour);
                hour = TimeHelper.AddMinutes(hours.Last(), 15);
            }

            return hours;
        }
    }
}