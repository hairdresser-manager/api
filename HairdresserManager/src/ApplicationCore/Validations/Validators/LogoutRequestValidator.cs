using ApplicationCore.Contract.V1.Authentication.Login.Requests;
using FluentValidation;

namespace ApplicationCore.Validations.Validators
{
    public class LogoutRequestValidator : AbstractValidator<LogoutRequest>
    {
        public LogoutRequestValidator()
        {
            RuleFor(request => request.RefreshToken)
                .NotEmpty();
        }
    }
}