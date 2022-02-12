using ApplicationCore.Contract.V1.Authentication.Login.Requests;
using FluentValidation;

namespace ApplicationCore.Validations.Validators
{
    public class FacebookAuthRequestValidator : AbstractValidator<FacebookAuthRequest>
    {
        public FacebookAuthRequestValidator()
        {
            RuleFor(request => request.AccessToken)
                .NotEmpty();
        }
    }
}