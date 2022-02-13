using ApplicationCore.Contract.V1.Employee.Appointment.Requests;
using FluentValidation;

namespace ApplicationCore.Validations.Validators
{
    public class CreateEmployeeAppointmentRequestValidator : AbstractValidator<CreateEmployeeAppointmentRequest>
    {
        public CreateEmployeeAppointmentRequestValidator()
        {
            RuleFor(request => request.ClientFirstName)
                .NotEmpty();

            RuleFor(request => request.ClientEmail)
                .NotEmpty()
                .EmailAddress();

            RuleFor(request => request.ClientPhoneNumber)
                .NotEmpty();

            RuleFor(request => request.EmployeeId)
                .NotEmpty();

            RuleFor(request => request.ServiceId)
                .NotEmpty();

            RuleFor(request => request.Date)
                .NotEmpty()
                .Must(date => date.Minute % 15 == 0)
                .WithMessage("Date hour must by divisible by 15");
        }
    }
}