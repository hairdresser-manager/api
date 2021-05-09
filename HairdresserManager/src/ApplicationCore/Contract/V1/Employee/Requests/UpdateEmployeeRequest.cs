using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Validations;

namespace ApplicationCore.Contract.V1.Employee.Requests
{
    public class UpdateEmployeeRequest
    {
        [StringLength(50)]
        public string Nick { get; set; }
        
        [StringLength(255)]
        public string Description { get; set; }
        
        public bool Active { get; set; }
        public string AvatarUrl { get; set; }
        public string LowQualityAvatarUrl { get; set; }
    }
}