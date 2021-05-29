using ApplicationCore.Contract.V1.General.Requests;
using FluentValidation;

namespace ApplicationCore.Validations.Validators
{
    public class PaginationQueryRequestValidator : AbstractValidator<PaginationQueryRequest>
    {
        public PaginationQueryRequestValidator()
        {
            RuleFor(request => request.Page)
                .NotEmpty()
                .GreaterThan(0);
            
            RuleFor(request => request.PerPage)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}