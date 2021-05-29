using ApplicationCore.Contract.V1.ServiceCategory;
using FluentValidation;

namespace ApplicationCore.Validations.Validators
{
    public class CreateServicesCategoryRequestValidator : AbstractValidator<CreateServiceCategoryRequest>
    {
        public CreateServicesCategoryRequestValidator()
        {
            RuleFor(request => request.Name)
                .NotEmpty()
                .MinimumLength(5);
        }
    }
}