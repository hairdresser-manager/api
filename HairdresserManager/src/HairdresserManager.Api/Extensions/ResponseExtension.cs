using HairdresserManager.Shared.Contract.V1.General.Responses;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace HairdresserManager.Api.Extensions
{
    public static class ResponseExtension
    {
        public static void AddPaginationMetadataToHeaders(this HttpResponse response, PaginationMetadataResponse value)
        {
            var metadata = JsonConvert.SerializeObject(value);
            response.Headers.Add("X-Pagination", metadata);
        }
    }
}