using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Contract.V1.General.Requests;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Helpers;
using ApplicationCore.Results;

namespace ApplicationCore.Interfaces
{
    public interface IReviewService
    {
        Task<bool> ReviewExistsByAppointmentIdAsync(int appointmentId);
        Task<ServiceResult> UserCanCreateReviewAsync(Guid userId, int appointmentId);
        Task<bool> CreateReviewAsync(ReviewDto reviewDto);
        Task<IEnumerable<ReviewDetailsViewDto>> GetReviewDtosAsync(PaginationHelper pagination);
    }
}