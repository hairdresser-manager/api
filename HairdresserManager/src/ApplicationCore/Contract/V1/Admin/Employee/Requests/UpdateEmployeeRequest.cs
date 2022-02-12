namespace ApplicationCore.Contract.V1.Admin.Employee.Requests
{
    public class UpdateEmployeeRequest
    {
        public string Nick { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }
        public string AvatarUrl { get; set; }
        public string LowQualityAvatarUrl { get; set; }
    }
}