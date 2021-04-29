using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Contract.V1.Account.Requests
{
    public class VerifyEmailRequest
    {
        [Required]
        public string Token { get; set; }
        
        [Required]
        public string Email { get; set; }
    }
}