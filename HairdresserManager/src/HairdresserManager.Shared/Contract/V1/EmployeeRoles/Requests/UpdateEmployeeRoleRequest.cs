using System.ComponentModel.DataAnnotations;

namespace HairdresserManager.Shared.Contract.V1.EmployeeRoles.Requests
{
    public class UpdateEmployeeRoleRequest
    {
        [Required]
        public string NewRoleName { get; set; }
    }
}