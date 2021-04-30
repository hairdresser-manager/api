namespace ApplicationCore.Entities
{
    public class ServiceEmployeeRole
    {
        public int Id { get; set; }
        public int EmployeeRoleId { get; set; }
        public int ServiceId { get; set; }

        public EmployeesRole EmployeeRole { get; set; }
        public Service Service { get; set; }
    }
}