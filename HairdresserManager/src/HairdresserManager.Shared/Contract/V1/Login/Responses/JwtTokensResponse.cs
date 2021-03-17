using System;

namespace HairdresserManager.Shared.Contract.V1.Login.Responses
{
    public class JwtTokensResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}