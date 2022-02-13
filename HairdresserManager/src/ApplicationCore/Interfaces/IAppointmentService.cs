using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Results;

namespace ApplicationCore.Interfaces
{
    public interface IAppointmentService
    {
        Task<ICollection<FreeDateDto>> GetFreeDatesAsync(IEnumerable<int> employeeIds, DateTime startDate,
            DateTime endDate, int serviceDuration);

        Task<ServiceResult> CreateAppointmentAsync(AppointmentDto appointmentDto);
        Task<IEnumerable<AppointmentEmployeeDetailsDto>> GetAppointmentDetailsDtosByUserIdAsync(Guid userId);
        Task<ServiceResult> CancelUserAppointmentByIdAsync(Guid userId, int appointmentId);

        Task<IEnumerable<AppointmentClientDetailsDto>> GetAppointmentDetailsDtosByEmployeeIdAsync(DateTime date,
            int employeeId);
    }
}