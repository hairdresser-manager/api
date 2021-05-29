using ApplicationCore.Contract.V1.Appointment.Requests;
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
                .NotEmpty();
            
            RuleFor(request => request.Hour)
                .NotEmpty();
        }
    }
}