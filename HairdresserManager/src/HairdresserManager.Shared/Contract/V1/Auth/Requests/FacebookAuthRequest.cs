using System.ComponentModel.DataAnnotations;

namespace HairdresserManager.Shared.Contract.V1.Auth.Requests
{
    public class FacebookAuthRequest
    {
        [Required]
        public string AccessToken { get; set; }
    }
}