using ApplicationCore.Contract.V1.Admin.Employee.Requests;
using FluentValidation;

namespace ApplicationCore.Validations.Validators
{
    public class CreateEmployeeRequestValidator : AbstractValidator<CreateEmployeeRequest>
    {
        public CreateEmployeeRequestValidator()
        {
            RuleFor(request => request.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}