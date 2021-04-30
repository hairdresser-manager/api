using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class EmployeesRole
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<EmployeeRole> EmployeeRoles { get; set; }
        public IEnumerable<ServiceEmployeeRole> ServicesEmployeeRoles { get; set; }
    }
}