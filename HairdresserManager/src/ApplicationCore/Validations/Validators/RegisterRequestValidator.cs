using ApplicationCore.Contract.V1.Authentication.Register.Requests;
using FluentValidation;

namespace ApplicationCore.Validations.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(request => request.Email)
                .EmailAddress()
                .NotEmpty();
            
            RuleFor(request => request.Password)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(18)
                .Matches(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$");
            
            RuleFor(request => request.ReTypedPassword)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(18)
                .Matches(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")
                .Equal(request => request.Password);

            RuleFor(request => request.FirstName)
                .MinimumLength(2)
                .MaximumLength(30)
                .NotEmpty();
            
            RuleFor(request => request.LastName)
                .MinimumLength(2)
                .MaximumLength(30)
                .NotEmpty();
            
            RuleFor(request => request.MobilePhone)
                .NotEmpty()
                .MinimumLength(9)
                .MaximumLength(15)
                .Matches(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$");
        }
    }
}