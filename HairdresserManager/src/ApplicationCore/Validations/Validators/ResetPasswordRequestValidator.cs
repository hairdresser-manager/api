using ApplicationCore.Contract.V1.Authentication.PasswordRecovery.Requests;
using FluentValidation;

namespace ApplicationCore.Validations.Validators
{
    public class ResetPasswordRequestValidator : AbstractValidator<ResetPasswordRequest>
    {
        public ResetPasswordRequestValidator()
        {
            RuleFor(request => request.NewPassword)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(18)
                .Matches(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$");
            
            RuleFor(request => request.ReTypedNewPassword)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(18)
                .Matches(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")
                .Equal(request => request.NewPassword);

            RuleFor(request => request.ResetPasswordKey)
                .NotEmpty();
        }
    }
}