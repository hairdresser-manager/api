using System.Collections.Generic;
using System.Linq;
using HairdresserManager.Api.Extensions;
using HairdresserManager.Shared.Contract.V1.General.Requests;
using HairdresserManager.Shared.Contract.V1.General.Responses;
using HairdresserManager.Shared.Contract.V1.Review.Requests;
using HairdresserManager.Shared.Contract.V1.Review.Responses;
using Microsoft.AspNetCore.Mvc;

namespace HairdresserManager.Api.Controllers.V1
{
    [ApiController]
    public class ReviewController : ControllerBase
    {
        [HttpGet("api/v1/reviews")]
        public IActionResult GetReviews([FromQuery] PaginationQueryRequest pagination)
        {
            var data = new List<ReviewResponse>
            {
                new ReviewResponse {Description = "not bad", Rate = 4, ReviewId = 1},
                new ReviewResponse {Description = "Good", Rate = 5, ReviewId = 2},
                new ReviewResponse {Description = "Terrible", Rate = 2, ReviewId = 3},
                new ReviewResponse {Description = "Useless", Rate = 1, ReviewId = 4},
                new ReviewResponse {Description = "Grinding", Rate = 2, ReviewId = 5},
                new ReviewResponse {Description = "Abysmal", Rate = 2, ReviewId = 6},
                new ReviewResponse {Description = "Abject", Rate = 1, ReviewId = 7},
                new ReviewResponse {Description = "Excellent", Rate = 5, ReviewId = 8}
            };

            var resources = data.Skip(pagination.CountItemsToSkip()).Take(pagination.PerPage);
            var metadata = new PaginationMetadataResponse(pagination, data.Count);
            Response.AddPaginationMetadataToHeaders(metadata);

            return Ok(resources);
        }

        [HttpPost("api/v1/reviews")]
        public IActionResult CreateReview([FromBody] CreateReviewRequest request)
        {
            return NoContent();
        }

        [HttpDelete("api/v1/reviews/{reviewId}")]
        public IActionResult DeleteReview([FromRoute] int reviewId)
        {
            return NoContent();
        }
    }
}