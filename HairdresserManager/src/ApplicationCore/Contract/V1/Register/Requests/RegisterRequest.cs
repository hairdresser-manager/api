using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Contract.V1.Register.Requests
{
    public class RegisterRequest
    {
        [Required]        
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Password must contain lowercase letter, capital letter and number.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        
        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Password must contain lowercase letter, capital letter and number.")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "ReTypedPassword")]
        public string ReTypedPassword { get; set; }

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