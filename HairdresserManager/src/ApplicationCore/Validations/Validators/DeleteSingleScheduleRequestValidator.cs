using ApplicationCore.Contract.V1.Schedule;
using FluentValidation;

namespace ApplicationCore.Validations.Validators
{
    public class DeleteSingleScheduleRequestValidator : AbstractValidator<DeleteSingleScheduleRequest>
    {
        public DeleteSingleScheduleRequestValidator()
        {
            RuleFor(request => request.Date)
                .NotEmpty();
        }
    }
}