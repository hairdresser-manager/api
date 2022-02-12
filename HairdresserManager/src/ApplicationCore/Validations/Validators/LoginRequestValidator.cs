using ApplicationCore.Contract.V1.Authentication.Login.Requests;
using FluentValidation;

namespace ApplicationCore.Validations.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(request => request.Password)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(18)
                .Matches(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$");
        }
    }
}