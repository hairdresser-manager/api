using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Contract.V1.Login.Requests
{
    public class LogoutRequest
    {
        [Required] 
        public Guid RefreshToken { get; set; }
    }
}