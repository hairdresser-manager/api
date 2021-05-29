using ApplicationCore.Contract.V1.Account.Requests;
using FluentValidation;

namespace ApplicationCore.Validations.Validators
{
    public class UpdateResourceRequestValidator : AbstractValidator<UpdateAccountRequest>
    {
        public UpdateResourceRequestValidator()
        {
            
        }
    }
}