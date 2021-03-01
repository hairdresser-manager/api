using System;

namespace HairdresserManager.Shared.Contract.V1.Auth.Responses
{
    public class LoginResponse
    {
        public string AccessToken { get; set; }
        public Guid RefreshToken { get; set; }
    }
}