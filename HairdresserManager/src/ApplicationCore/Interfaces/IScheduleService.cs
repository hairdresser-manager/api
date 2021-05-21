using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Results;

namespace ApplicationCore.Interfaces
{
    public interface IScheduleService
    {
        Task<ServiceResult> CreateScopedScheduleAsync(int employeeId, IEnumerable<DateTime> dates, string startHour,
            string endHour);

        Task<ServiceResult> CreateScheduleAsync(int employeeId, DateTime date, string startHour, string endHour);
        Task<ServiceResult> DeleteScopedScheduleAsync(int employeeId, DateTime startDate, DateTime endDate);
        Task<ServiceResult> DeleteScheduleAsync(int employeeId, DateTime date);
        Task<IEnumerable<ScheduleDto>> GetSchedulesDtoByEmployeeIdAsync(int employeeId);
    }
}