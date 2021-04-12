using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Contract.V1.ResourceCategory.Requests
{
    public class UpdateResourcesCategoryRequest
    {
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Name { get; set; }
        
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Description { get; set; }
    }
}