using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace WebApi.Extensions
{
    public static class GetCurrentUserIdExtension
    {
        public static string GetUserId(this HttpContext httpContext)
        {
            return httpContext.User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value;
        }
    }
}