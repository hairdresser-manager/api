using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Validations;

namespace ApplicationCore.Contract.V1.Employee.Requests
{
    public class UpdateEmployeeRequest
    {
        [EmailAddress]
        public string Email { get; set; }
        
        [StringLength(50)]
        public string FirstName { get; set; }
        
        [StringLength(50)]
        public string LastName { get; set; }
        
        [Phone]
        [StringLength(13, MinimumLength = 3, ErrorMessage = "Phone number must be between 3 and 13 letters in length.")]
        public string PhoneNumber { get; set; }
        
        [StringLength(255)]
        public string Description { get; set; }
        
        public bool Active { get; set; }
        
        [StringLengthInList(50, ErrorMessage = "Elements in list Roles can be up to 50 characters length")]
        public IEnumerable<string> Roles  { get; set; }
        

    }
}