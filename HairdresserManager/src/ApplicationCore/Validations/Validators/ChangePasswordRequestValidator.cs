using ApplicationCore.Contract.V1.Account.Requests;
using FluentValidation;

namespace ApplicationCore.Validations.Validators
{
    public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
    {
        public ChangePasswordRequestValidator()
        {
            RuleFor(request => request.CurrentPassword)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(18)
                .Matches(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$");
            
            RuleFor(request => request.NewPassword)
                .NotEmpty()
                .NotEqual(request => request.CurrentPassword)
                .MinimumLength(6)
                .MaximumLength(18)
                .Matches(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$");
            
            RuleFor(request => request.ReTypedNewPassword)
                .NotEmpty()
                .Equal(request => request.NewPassword)
                .MinimumLength(6)
                .MaximumLength(18)
                .Matches(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$");
        }   
    }
}