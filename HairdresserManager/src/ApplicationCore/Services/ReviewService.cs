using System;
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
    }
}