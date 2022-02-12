namespace ApplicationCore.Contract.V1.Authentication.Register.Requests
{
    public class VerifyEmailRequest
    {
        public string Token { get; set; }
        public string Email { get; set; }
    }
}