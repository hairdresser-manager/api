using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Contract.V1.EmployeeRoles.Requests
{
    public class CreateEmployeeRoleRequest
    {
        [Required]
        [StringLength(20)]
        public string Role { get; set; }
    }
}