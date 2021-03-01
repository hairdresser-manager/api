using System;
using System.ComponentModel.DataAnnotations;

namespace HairdresserManager.Shared.Contract.V1.Auth.Requests
{
    public class RefreshTokenRequest
    {
        [Required] 
        public string AccessToken { get; set; }

        [Required]
        public Guid RefreshToken { get; set; }
    }
}