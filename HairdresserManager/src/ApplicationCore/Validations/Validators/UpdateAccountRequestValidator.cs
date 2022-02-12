using ApplicationCore.Contract.V1.User.Account.Requests;
using FluentValidation;

namespace ApplicationCore.Validations.Validators
{
    public class UpdateAccountRequestValidator : AbstractValidator<UpdateAccountRequest>
    {
        public UpdateAccountRequestValidator()
        {
            RuleFor(request => request.FirstName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(30);
            
            RuleFor(request => request.LastName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(30);

            RuleFor(request => request.MobilePhone)
                .NotEmpty()
                .MinimumLength(9)
                .MaximumLength(15)
                .Matches(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$");

        }
    }
}