using ApplicationCore.Contract.V1.EmployeeService;
using FluentValidation;

namespace ApplicationCore.Validations.Validators
{
    public class RemoveEmployeeFromServiceRequestValidator : AbstractValidator<RemoveEmployeeFromServiceRequest>
    {
        public RemoveEmployeeFromServiceRequestValidator()
        {
            RuleFor(request => request.EmployeeId)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}