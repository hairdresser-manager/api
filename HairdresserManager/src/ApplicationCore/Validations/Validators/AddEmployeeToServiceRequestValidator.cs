using ApplicationCore.Contract.V1.EmployeeService;
using FluentValidation;

namespace ApplicationCore.Validations.Validators
{
    public class AddEmployeeToServiceRequestValidator : AbstractValidator<AddEmployeeToServiceRequest>
    {
        public AddEmployeeToServiceRequestValidator()
        {
            RuleFor(request => request.EmployeeId)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}