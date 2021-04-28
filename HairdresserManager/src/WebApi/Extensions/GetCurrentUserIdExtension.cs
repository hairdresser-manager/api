using System.Linq;
using Microsoft.AspNetCore.Http;

namespace WebApi.Extensions
{
    public static class GetCurrentUserIdExtension
    {
        public static string GetUserId(this HttpContext httpContext)
        {
            if(httpContext.User == null)
                return string.Empty;

            return httpContext.User.Claims.Single(x => x.Type == "sub").Value;
        }
    }
}