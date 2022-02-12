using ApplicationCore.Contract.V1.Admin.Service.Requests;
using FluentValidation;

namespace ApplicationCore.Validations.Validators
{
    public class UpdateServiceRequestValidator : AbstractValidator<UpdateServiceRequest>
    {
        public UpdateServiceRequestValidator()
        {
            RuleFor(request => request.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(30);

            RuleFor(request => request.CategoryId)
                .NotEmpty()
                .GreaterThan(0);
            
            RuleFor(request => request.Description)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(1024);
            
            RuleFor(request => request.MinimumTime)
                .NotEmpty()
                .GreaterThan(9);

            RuleFor(request => request.MaximumTime)
                .NotEmpty()
                .GreaterThan(9)
                .GreaterThan(request => request.MinimumTime)
                .LessThan(500);
            
            RuleFor(request => request.Price)
                .GreaterThan(0)
                .LessThan(999999)
                .NotEmpty();
            
            RuleFor(request => request.Available)
                .NotNull();
        }
    }
}