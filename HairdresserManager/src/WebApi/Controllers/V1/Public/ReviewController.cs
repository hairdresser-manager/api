using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Contract.V1.General.Requests;
using ApplicationCore.Contract.V1.General.Responses;
using ApplicationCore.Contract.V1.Review.Responses;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;

namespace WebApi.Controllers.V1.Public
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "Public / Reviews")]
    public class ReviewController : ControllerBase
    {
        [HttpGet("api/v1/reviews")]
        public IActionResult GetReviews([FromQuery] PaginationQueryRequest pagination)
        {
            var data = new List<ReviewResponse>
            {
                new ReviewResponse {Description = "not bad", Rate = 4, ReviewId = 1, Date = DateTime.Now.ToString(), Nick = "Bartosh W."},
                new ReviewResponse {Description = "Good", Rate = 5, ReviewId = 2, Date = DateTime.Now.AddDays(1).ToString(), Nick = "John S."},
                new ReviewResponse {Description = "Terrible", Rate = 2, ReviewId = 3, Date = DateTime.Now.AddDays(2).ToString(), Nick = "George C."},
                new ReviewResponse {Description = "Useless", Rate = 1, ReviewId = 4, Date = DateTime.Now.AddDays(3).ToString(), Nick = "Natalie P."},
                new ReviewResponse {Description = "Grinding", Rate = 2, ReviewId = 5, Date = DateTime.Now.AddDays(4).ToString(), Nick = "Mike T."},
                new ReviewResponse {Description = "Abysmal", Rate = 2, ReviewId = 6, Date = DateTime.Now.AddDays(5).ToString(), Nick = "Alexandra B."},
                new ReviewResponse {Description = "Abject", Rate = 1, ReviewId = 7, Date = DateTime.Now.AddDays(6).ToString(), Nick = "Andrea B."},
                new ReviewResponse {Description = "Excellent", Rate = 5, ReviewId = 8, Date = DateTime.Now.AddDays(7).ToString(), Nick = "Nemsko A."}
            };

            var resources = data.Skip(pagination.ItemsToSkip()).Take(pagination.PerPage);
            var metadata = new PaginationMetadataResponse(pagination, data.Count);
            Response.AddPaginationMetadataToHeaders(metadata);

            return Ok(resources);
        }
    }
}