using ApplicationCore.Contract.V1.Resource.Requests;
using FluentValidation;

namespace ApplicationCore.Validations.Validators
{
    public class CreateResourceRequestValidator : AbstractValidator<CreateResourceRequest>
    {
        public CreateResourceRequestValidator()
        {
            
        }
    }
}