using ApplicationCore.Contract.V1.Review.Requests;
using FluentValidation;

namespace ApplicationCore.Validations.Validators
{
    public class CreateReviewRequestValidator : AbstractValidator<CreateReviewRequest>
    {
        public CreateReviewRequestValidator()
        {
            RuleFor(request => request.AppointmentId)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(request => request.Rate)
                .NotEmpty()
                .GreaterThan(0)
                .LessThan(6);

            RuleFor(request => request.Description)
                .MaximumLength(512);
        }
    }
}