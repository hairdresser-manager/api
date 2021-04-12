using System.ComponentModel.DataAnnotations;

namespace HairdresserManager.Shared.Contract.V1.ResourceCategory.Requests
{
    public class CreateResourcesCategoryRequest
    {
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Name { get; set; }

        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Description { get; set; }
    }
}