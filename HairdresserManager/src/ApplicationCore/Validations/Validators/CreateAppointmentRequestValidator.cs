using ApplicationCore.Contract.V1.Client.Appointment.Requests;
using FluentValidation;

namespace ApplicationCore.Validations.Validators
{
    public class CreateAppointmentRequestValidator : AbstractValidator<CreateAppointmentRequest>
    {
        public CreateAppointmentRequestValidator()
        {
            RuleFor(request => request.EmployeeId)
                .NotEmpty();
            
            RuleFor(request => request.ServiceId)
                .NotEmpty();
            
            RuleFor(request => request.Date)
                .Must(date => date.Minute % 15 == 0)
                .WithMessage("Minute must be divisible by 15")
                .NotEmpty();
        }
    }
}