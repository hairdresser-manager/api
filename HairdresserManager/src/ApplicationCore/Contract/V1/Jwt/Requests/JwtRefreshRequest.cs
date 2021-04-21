using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Contract.V1.Jwt.Requests
{
    public class JwtRefreshRequest
    {
        [Required] 
        public string AccessToken { get; set; }

        [Required]
        public string RefreshToken { get; set; }
    }
}