using ApplicationCore.Contract.V1.Schedule;
using FluentValidation;

namespace ApplicationCore.Validations.Validators
{
    public class DeleteScopedScheduleRequestValidator : AbstractValidator<DeleteScopedScheduleRequest>
    {
        public DeleteScopedScheduleRequestValidator()
        {
            RuleFor(request => request.StartDate)
                .NotEmpty();
            
            RuleFor(request => request.EndDate)
                .NotEmpty();
        }
    }
}