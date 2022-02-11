using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Results;

namespace ApplicationCore.Interfaces
{
    public interface IAppointmentService
    {
        Task<ICollection<FreeDateDto>> GetFreeDatesAsync(IEnumerable<int> employeeIds, DateTime startDate,
            DateTime endDate, int serviceDuration);
        Task<ServiceResult> CreateAppointmentAsync(AppointmentDto appointmentDto);
    }
}