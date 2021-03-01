using System.ComponentModel.DataAnnotations;

namespace HairdresserManager.Shared.Contract.V1.Auth.Requests
{
    public class RemindPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}