namespace ApplicationCore.Settings
{
    public class JwtSettings
    {
        public string SigningKey { get; set; }
        public string Issuer { get; set; }
        public string AccessTokenLifeTimeInSeconds { get; set; }
        public string RefreshTokenLifeTimeInDays { get; set; }
    }
}