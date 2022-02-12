using ApplicationCore.Contract.V1.Admin.Schedule;
using FluentValidation;

namespace ApplicationCore.Validations.Validators
{
    public class CreateScopedScheduleRequestValidator : AbstractValidator<CreateScopedScheduleRequest>
    {
        public CreateScopedScheduleRequestValidator()
        {
            RuleFor(request => request.StartDate)
                .NotEmpty();
            
            RuleFor(request => request.EndDate)
                .NotEmpty();
            
            RuleFor(request => request.WeekDays)
                .NotEmpty();
            
            RuleFor(request => request.StartHour)
                .NotEmpty();

            RuleFor(request => request.EndHour)
                .NotEmpty();
        }
    }
}