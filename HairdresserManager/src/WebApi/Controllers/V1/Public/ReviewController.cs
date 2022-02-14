using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contract.V1.General.Requests;
using ApplicationCore.Contract.V1.General.Responses;
using ApplicationCore.Contract.V1.Public.Review;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;

namespace WebApi.Controllers.V1.Public
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "Public / Reviews")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;

        public ReviewController(IReviewService reviewService, IMapper mapper)
        {
            _reviewService = reviewService;
            _mapper = mapper;
        }

        [HttpGet("api/v1/reviews")]
        public async Task<IActionResult> GetReviews([FromQuery] PaginationQueryRequest pagination)
        {
            var paginationHelper = new PaginationHelper(pagination);
            
            var reviewDtos = await _reviewService.GetReviewDtosAsync(paginationHelper);

            var metadata = _mapper.Map<PaginationMetadataResponse>(paginationHelper);
            Response.AddPaginationMetadataToHeaders(metadata);

            return Ok(_mapper.Map<IEnumerable<ReviewListItemResponse>>(reviewDtos));
        }
    }
}