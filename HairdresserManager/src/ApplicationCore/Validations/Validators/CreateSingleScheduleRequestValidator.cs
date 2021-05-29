using ApplicationCore.Contract.V1.Schedule;
using FluentValidation;

namespace ApplicationCore.Validations.Validators
{
    public class CreateSingleScheduleRequestValidator : AbstractValidator<CreateSingleScheduleRequest>
    {
        public CreateSingleScheduleRequestValidator()
        {
            RuleFor(request => request.Date)
                .NotEmpty();
            
            RuleFor(request => request.StartHour)
                .NotEmpty();
            
            RuleFor(request => request.EndHour)
                .NotEmpty();
        }
    }
}