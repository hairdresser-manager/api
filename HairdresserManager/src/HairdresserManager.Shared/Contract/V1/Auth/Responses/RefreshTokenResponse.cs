using System;

namespace HairdresserManager.Shared.Contract.V1.Auth.Responses
{
    public class RefreshTokenResponse
    {
        public string AccessToken { get; set; }
        public Guid RefreshToken { get; set; }
    }
}