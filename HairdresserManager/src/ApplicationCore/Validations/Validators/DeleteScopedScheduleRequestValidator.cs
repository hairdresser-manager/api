using ApplicationCore.Contract.V1.Admin.Schedule;
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