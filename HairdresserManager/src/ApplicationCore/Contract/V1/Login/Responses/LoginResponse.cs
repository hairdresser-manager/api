using System.Collections.Generic;

namespace ApplicationCore.Contract.V1.Login.Responses
{
    public class LoginResponse
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}