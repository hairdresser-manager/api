using System;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Results;

namespace ApplicationCore.Interfaces
{
    public interface IReviewService
    {
        Task<bool> ReviewExistsByAppointmentIdAsync(int appointmentId);
        Task<ServiceResult> UserCanCreateReviewAsync(Guid userId, int appointmentId);
        Task<bool> CreateReviewAsync(ReviewDto reviewDto);
    }
}