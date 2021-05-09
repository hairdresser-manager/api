using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Results;

namespace ApplicationCore.Interfaces
{
    public interface IScheduleService
    {
        Task<Result> CreateScopedScheduleAsync(int employeeId, IEnumerable<DateTime> dates, string startHour, string endHour);
        Task<Result> CreateScheduleAsync(int employeeId, DateTime date, string startHour, string endHour);
        Task<Result> DeleteScopedScheduleAsync(int employeeId, DateTime startDate, DateTime endDate);
        Task<Result> DeleteScheduleAsync(int employeeId, DateTime date);
    }
}