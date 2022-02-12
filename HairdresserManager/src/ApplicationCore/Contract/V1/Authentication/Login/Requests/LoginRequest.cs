namespace ApplicationCore.Contract.V1.Authentication.Login.Requests
{
    public class LoginRequest
    {
        public string Email { get; set; }
        
        public string Password { get; set; }
    }
}