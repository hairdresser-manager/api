using ApplicationCore.Contract.V1.PasswordRecovery.Requests;
using FluentValidation;

namespace ApplicationCore.Validations.Validators
{
    public class RemindPasswordRequestValidator : AbstractValidator<RemindPasswordRequest>
    {
        public RemindPasswordRequestValidator()
        {
            RuleFor(request => request.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}