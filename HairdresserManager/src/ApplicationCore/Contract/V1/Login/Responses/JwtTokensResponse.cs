namespace ApplicationCore.Contract.V1.Login.Responses
{
    public class JwtTokensResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}