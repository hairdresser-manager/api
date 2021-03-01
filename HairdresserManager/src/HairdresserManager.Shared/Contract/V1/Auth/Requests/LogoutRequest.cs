using System;
using System.ComponentModel.DataAnnotations;

namespace HairdresserManager.Shared.Contract.V1.Auth.Requests
{
    public class LogoutRequest
    {
        [Required] 
        public Guid RefreshToken { get; set; }
    }
}