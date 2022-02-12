using ApplicationCore.Contract.V1.Admin.Service.Requests;
using FluentValidation;

namespace ApplicationCore.Validations.Validators
{
    public class CreateServiceRequestValidator : AbstractValidator<CreateServiceRequest>
    {
        public CreateServiceRequestValidator()
        {
            RuleFor(request => request.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);

            RuleFor(request => request.CategoryId)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(request => request.Description)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(1024);

            RuleFor(request => request.MinimumTime)
                .NotEmpty()
                .Must(minimumTime => minimumTime % 15 == 0)
                .WithMessage("MinimumTime must be divisible by 15")
                .GreaterThan(0);

            RuleFor(request => request.MaximumTime)
                .NotEmpty()
                .Must(maximumTime => maximumTime % 15 == 0)
                .WithMessage("MaximumTime must be divisible by 15")
                .GreaterThanOrEqualTo(request => request.MinimumTime)
                .WithMessage("MaximumTime must be greater or equal to MinimumTime")
                .LessThan(1440);

            RuleFor(request => request.Price)
                .GreaterThan(0)
                .NotEmpty();

            RuleFor(request => request.Available)
                .NotNull();
        }
    }
}