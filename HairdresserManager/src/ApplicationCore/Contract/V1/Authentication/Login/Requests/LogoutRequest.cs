namespace ApplicationCore.Contract.V1.Authentication.Login.Requests
{
    public class LogoutRequest
    {
        public string RefreshToken { get; set; }
    }
}