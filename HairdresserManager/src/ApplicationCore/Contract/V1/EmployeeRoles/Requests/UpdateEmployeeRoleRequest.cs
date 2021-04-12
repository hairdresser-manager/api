using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Contract.V1.EmployeeRoles.Requests
{
    public class UpdateEmployeeRoleRequest
    {
        [Required]
        public string NewRoleName { get; set; }
    }
}