using ApplicationCore.Contract.V1.Admin.ServiceCategory;
using FluentValidation;

namespace ApplicationCore.Validations.Validators
{
    public class UpdateServicesCategoryRequestValidator : AbstractValidator<UpdateServicesCategoryRequest>
    {
        public UpdateServicesCategoryRequestValidator()
        {
            RuleFor(request => request.Name)
                .NotEmpty()
                .MinimumLength(5);
        }
    }
}