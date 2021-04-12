using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Contract.V1.Account.Requests
{
    public class ChangePasswordRequest
    { 
        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Password must contain lowercase letter, capital letter and number.")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        
        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Password must contain lowercase letter, capital letter and number.")]
        [DataType(DataType.Password)]
        [Compare("ReTypedNewPassword")]
        public string NewPassword { get; set; }
        
        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Password must contain lowercase letter, capital letter and number.")]
        [DataType(DataType.Password)]
        public string ReTypedNewPassword { get; set; }
    }
}