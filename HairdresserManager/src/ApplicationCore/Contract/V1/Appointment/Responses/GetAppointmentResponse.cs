namespace ApplicationCore.Contract.V1.Appointment.Responses
{
    public class GetAppointmentResponse
    {
        public int AppointmentId { get; set; }
        public string Date { get; set; }
        public string Hour { get; set; }
        public string ServiceName { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLowQualityAvatar { get; set; }
        public bool Rated { get; set; }
    }
}