using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Validations;

namespace ApplicationCore.Contract.V1.Service.Requests
{
    public class UpdateServiceRequest
    {
        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Name { get; set; }
        
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Elements in list Categories can be up to 50 characters length")]
        public int CategoryId { get; set; }
        
        [Required]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Description { get; set; }

        [Required]
        [Range(10, 500, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int MinimumTime { get; set; }

        [Required]
        [Range(10, 500, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int MaximumTime { get; set; }

        [Required]
        [Range(0, 10000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public decimal Price { get; set; }
        
        [Required]
        public bool Available { get; set; }
    }
}