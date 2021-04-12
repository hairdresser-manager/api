namespace ApplicationCore.Contract.V1.Jwt.Responses
{
    public class JwtRefreshResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}