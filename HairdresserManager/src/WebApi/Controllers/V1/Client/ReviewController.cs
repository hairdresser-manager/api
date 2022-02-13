using System;
using System.Threading.Tasks;
using ApplicationCore.Contract.V1.Client.Review.Requests;
using ApplicationCore.Contract.V1.General.Responses;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;

namespace WebApi.Controllers.V1.Client
{
    [ApiController]
    [Authorize(Roles = "User")]
    [Route("api/v1/reviews")]
    [ApiExplorerSettings(GroupName = "Client / Reviews")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;

        public ReviewController(IReviewService reviewService, IAppointmentService appointmentService, IMapper mapper)
        {
            _reviewService = reviewService;
            _appointmentService = appointmentService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewRequest request)
        {
            var userId = Guid.Parse(HttpContext.GetUserId());
            var result = await _reviewService.UserCanCreateReviewAsync(userId, request.AppointmentId);

            if (!result.Succeeded)
                return BadRequest(new ErrorResponse(result.Errors));

            var reviewDto = _mapper.Map<ReviewDto>(request);
            reviewDto.Date = DateTime.Now;

            var created = await _reviewService.CreateReviewAsync(reviewDto);

            return created ? NoContent() : BadRequest("User can't create this review");
        }
    }
}