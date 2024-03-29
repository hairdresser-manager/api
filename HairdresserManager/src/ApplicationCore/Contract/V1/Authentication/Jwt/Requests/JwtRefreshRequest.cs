using System;

namespace ApplicationCore.Contract.V1.Authentication.Jwt.Requests
{
    public class JwtRefreshRequest
    {
        public string AccessToken { get; set; }
        public Guid RefreshToken { get; set; }
    }
}