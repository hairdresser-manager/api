using System;

namespace ApplicationCore.Contract.V1.Login.Requests
{
    public class LogoutRequest
    {
        public string RefreshToken { get; set; }
    }
}