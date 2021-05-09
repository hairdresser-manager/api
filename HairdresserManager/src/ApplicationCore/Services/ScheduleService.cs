using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Results;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IHairdresserDbContext _context;
        private readonly IMapper _mapper;

        public ScheduleService(IHairdresserDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result> CreateScopedScheduleAsync(int employeeId, IEnumerable<DateTime> dates,
            string startHour,
            string endHour)
        {
            var schedules = new List<Schedule>();

            foreach (var date in dates)
            {
                if (await GetEmployeeScheduleById(employeeId, date) != null)
                    continue;

                var schedule = new Schedule
                {
                    EmployeeId = employeeId,
                    Date = date,
                    StartingHour = startHour,
                    EndingHour = endHour
                };

                schedules.Add(schedule);
            }

            if (!schedules.Any())
                return Result.Failure("Employee already has schedule at these dates");

            await _context.Schedules.AddRangeAsync(schedules);
            return await _context.SaveChangesAsync(new CancellationToken()) > 0
                ? Result.Success()
                : Result.Failure("Something went wrong");
        }

        public async Task<Result> CreateScheduleAsync(int employeeId, DateTime date, string startHour, string endHour)
        {
            if (await GetEmployeeScheduleById(employeeId, date) != null)
                return Result.Failure("Schedule on this date for that employee already exists");

            var schedule = new Schedule
            {
                EmployeeId = employeeId,
                Date = date,
                StartingHour = startHour,
                EndingHour = endHour
            };

            await _context.Schedules.AddAsync(schedule);
            return await _context.SaveChangesAsync(new CancellationToken()) > 0
                ? Result.Success()
                : Result.Failure("Something went wrong");
        }

        public async Task<Result> DeleteScopedScheduleAsync(int employeeId, DateTime startDate, DateTime endDate)
        {
            var schedulesToDelete = new List<Schedule>();

            do
            {
                var schedule = await GetEmployeeScheduleById(employeeId, startDate);

                if (schedule != null)
                    schedulesToDelete.Add(schedule);

                startDate = startDate.AddDays(1);
            } while (startDate <= endDate);


            if (!schedulesToDelete.Any())
                return Result.Failure("Schedule on this dates for that employee doesn't exist");

            _context.Schedules.RemoveRange(schedulesToDelete);
            return await _context.SaveChangesAsync(new CancellationToken()) > 0
                ? Result.Success()
                : Result.Failure("Something went wrong");
        }

        public async Task<Result> DeleteScheduleAsync(int employeeId, DateTime date)
        {
            var schedule = await GetEmployeeScheduleById(employeeId, date);

            if (schedule == null)
                return Result.Failure("Schedule on this date for that employee doesn't exist");

            _context.Schedules.Remove(schedule);
            return await _context.SaveChangesAsync(new CancellationToken()) > 0
                ? Result.Success()
                : Result.Failure("Something went wrong");
        }

        public async Task<IEnumerable<ScheduleDto>> GetSchedulesDtoByEmployeeIdAsync(int employeeId)
        {
            var schedules = await _context.Schedules
                .Where(s => s.EmployeeId == employeeId && s.Date >= DateTime.Today)
                .OrderBy(schedule => schedule.Date)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ScheduleDto>>(schedules);
        }

        private async Task<Schedule> GetEmployeeScheduleById(int employeeId, DateTime scheduleDate) =>
            await _context.Schedules.FirstOrDefaultAsync(s =>
                s.EmployeeId == employeeId && s.Date.Equals(scheduleDate));
    }
}