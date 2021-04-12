using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Contract.V1.Login.Requests
{
    public class LoginRequest
    {
        [Required]        
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}