using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Contract.V1.PasswordRecovery.Requests
{
    public class RemindPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}