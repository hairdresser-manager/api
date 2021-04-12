using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Contract.V1.Login.Requests
{
    public class FacebookAuthRequest
    {
        [Required]
        public string AccessToken { get; set; }
    }
}