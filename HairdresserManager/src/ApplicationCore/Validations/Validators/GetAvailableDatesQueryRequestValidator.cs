using System;
using ApplicationCore.Contract.V1.Client.Appointment.Requests;
using FluentValidation;

namespace ApplicationCore.Validations.Validators
{
    public class GetAvailableDatesQueryRequestValidator : AbstractValidator<GetAvailableDatesQueryRequest>
    {
        public GetAvailableDatesQueryRequestValidator()
        {
            RuleFor(request => request.Employees)
                .Must(employees => employees is {Count: > 0})
                .WithMessage("Employees must have at least 1 employeeId");
            
            RuleFor(request => request.StartDate)
                .NotNull()
                .GreaterThanOrEqualTo(DateTime.UtcNow.Date)
                .WithMessage("StartDate must be greater or equal to today's date");

            RuleFor(request => request.EndDate)
                .NotNull()
                .GreaterThanOrEqualTo(request => request.StartDate)
                .WithMessage("EndDate must be greater or equal to EndDate")
                .LessThan(request => request.StartDate.AddMonths(6))
                .WithMessage("EndDate must be less than StartDate + 6 months");
            
            RuleFor(request => request.ServiceDuration)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("ServiceDuration must be greater than 0")
                .Must(serviceDuration => serviceDuration % 15 == 0)
                .WithMessage("ServiceDuration must be divisible by 15");
        }
    }
}