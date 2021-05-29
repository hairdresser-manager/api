using ApplicationCore.Contract.V1.Employee.Requests;
using FluentValidation;

namespace ApplicationCore.Validations.Validators
{
    public class UpdateEmployeeRequestValidator : AbstractValidator<UpdateEmployeeRequest>
    {
        public UpdateEmployeeRequestValidator()
        {
            RuleFor(request => request.Nick)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(15);
            
            RuleFor(request => request.Description)
                .NotEmpty()
                .MinimumLength(30)
                .MaximumLength(255);

            RuleFor(request => request.Active)
                .NotNull();

            RuleFor(request => request.AvatarUrl)
                .NotEmpty();

            RuleFor(request => request.LowQualityAvatarUrl)
                .NotEmpty();
        }
    }
}