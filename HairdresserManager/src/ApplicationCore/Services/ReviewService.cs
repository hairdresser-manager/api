using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Contract.V1.General.Requests;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using ApplicationCore.Results;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IHairdresserDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public ReviewService(IHairdresserDbContext context, IMapper mapper, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<ServiceResult> UserCanCreateReviewAsync(Guid userId, int appointmentId)
        {
            var userDto = await _userService.GetUserDtoByIdAsync(userId.ToString());

            var userCanCreateReview = await _context.Appointments.Where(appointment =>
                appointment.Id == appointmentId &&
                (appointment.ClientEmail == userDto.Email ||
                 appointment.Client.UserId == userId)).AnyAsync();

            if (!userCanCreateReview)
                return ServiceResult.Failure("User can't create review to this appointment");

            var alreadyReviewed =
                await _context.Reviews.Where(review => review.AppointmentId == appointmentId).AnyAsync();

            return alreadyReviewed ? ServiceResult.Failure("Appointment already reviewed") : ServiceResult.Success();
        }

        public async Task<bool> ReviewExistsByAppointmentIdAsync(int appointmentId) =>
            await _context.Reviews.Where(review => review.AppointmentId == appointmentId).AnyAsync();

        public async Task<bool> CreateReviewAsync(ReviewDto reviewDto)
        {
            var review = _mapper.Map<Review>(reviewDto);

            await _context.Reviews.AddAsync(review);
            return await _context.SaveChangesAsync(new CancellationToken()) > 0;
        }

        public async Task<IEnumerable<ReviewDetailsViewDto>> GetReviewDetailsDtosAsync(PaginationHelper pagination)
        {
            var reviews = await _context.ReviewDetailsView
                .OrderBy(review => review.ReviewId)
                .Skip(pagination.ItemsToSkip)
                .Take(pagination.PerPage)
                .ToListAsync();
            
            pagination.TotalItems = await _context.ReviewDetailsView.CountAsync();
            return _mapper.Map<IEnumerable<ReviewDetailsViewDto>>(reviews);
        }

        public async Task<IEnumerable<ReviewDetailsViewDto>> GetEmployeeReviewDetailsDtosAsync(int employeeId, PaginationHelper pagination)
        {
            var reviews = await _context.ReviewDetailsView
                .Where(review => review.EmployeeId == employeeId)
                .OrderBy(review => review.ReviewId)
                .Skip(pagination.ItemsToSkip)
                .Take(pagination.PerPage)
                .ToListAsync();
            
            pagination.TotalItems = await _context.ReviewDetailsView.Where(review => review.EmployeeId == employeeId).CountAsync();
            return _mapper.Map<IEnumerable<ReviewDetailsViewDto>>(reviews);
        }
    }
}