using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Contract.V1.Account.Requests
{
    public class UpdateAccountRequest
    {
        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string LastName { get; set; }
        
        [Required]
        [Phone]
        [StringLength(13, MinimumLength = 3, ErrorMessage = "Phone number must be between 3 and 13 letters in length.")]
        public string MobilePhone { get; set; }
    }
}