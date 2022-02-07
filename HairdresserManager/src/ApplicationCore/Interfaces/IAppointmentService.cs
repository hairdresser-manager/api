using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
    public interface IAppointmentService
    {
        Task<ICollection<FreeDateDto>> GetFreeDatesAsync(ICollection<int> employeeIds, DateTime startDateUtc,
            DateTime endDateUtc, int serviceDuration);
    }
}