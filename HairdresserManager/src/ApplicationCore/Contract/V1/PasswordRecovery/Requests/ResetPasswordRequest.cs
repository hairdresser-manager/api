using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Contract.V1.PasswordRecovery.Requests
{
    public class ResetPasswordRequest
    {
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long and a maximum of {1}", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Password must contain lowercase letter, capital letter and number.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string NewPassword { get; set; }
        
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long and a maximum of {1}", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Password must contain lowercase letter, capital letter and number.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string ReTypedNewPassword { get; set; }
    }
}