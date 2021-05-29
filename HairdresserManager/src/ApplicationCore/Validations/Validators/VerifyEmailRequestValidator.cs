using ApplicationCore.Contract.V1.Register.Requests;
using FluentValidation;

namespace ApplicationCore.Validations.Validators
{
    public class VerifyEmailRequestValidator : AbstractValidator<VerifyEmailRequest>
    {
        public VerifyEmailRequestValidator()
        {
            RuleFor(request => request.Email)
                .NotEmpty()
                .EmailAddress();
            
            RuleFor(request => request.Token)
                .NotEmpty();
        }
    }
}