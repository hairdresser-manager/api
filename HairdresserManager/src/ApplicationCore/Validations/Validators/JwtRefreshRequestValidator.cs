using ApplicationCore.Contract.V1.Authentication.Jwt.Requests;
using FluentValidation;

namespace ApplicationCore.Validations.Validators
{
    public class JwtRefreshRequestValidator : AbstractValidator<JwtRefreshRequest>
    {
        public JwtRefreshRequestValidator()
        {
            RuleFor(request => request.AccessToken)
                .NotEmpty();
            
            RuleFor(request => request.RefreshToken)
                .NotEmpty();
        }
    }
}