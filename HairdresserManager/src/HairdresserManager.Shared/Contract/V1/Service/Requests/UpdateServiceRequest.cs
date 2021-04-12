using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HairdresserManager.Shared.Validations;

namespace HairdresserManager.Shared.Contract.V1.Service.Requests
{
    public class UpdateServiceRequest
    {
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Name { get; set; }

        [StringLengthInList(50, ErrorMessage = "Elements in list Categories can be up to 50 characters length")]
        public IEnumerable<string> Categories { get; set; }

        [StringLengthInList(50, ErrorMessage = "Elements in list Employees can be up to 50 characters length")]
        public IEnumerable<string> Employees { get; set; }

        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Description { get; set; }

        [Range(10, 500, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? MinimumTime { get; set; }

        [Range(10, 500, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? MaximumTime { get; set; }

        [Range(0, 10000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public decimal Price { get; set; }
        
        public bool? Available { get; set; }
    }
}