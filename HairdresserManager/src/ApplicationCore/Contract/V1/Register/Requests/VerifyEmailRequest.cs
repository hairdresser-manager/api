namespace ApplicationCore.Contract.V1.Register.Requests
{
    public class VerifyEmailRequest
    {
        public string Token { get; set; }
        public string Email { get; set; }
    }
}