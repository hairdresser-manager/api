namespace ApplicationCore.Contract.V1.Client.Appointment.Responses
{
    public class GetAppointmentResponse
    {
        public int AppointmentId { get; set; }
        public string Date { get; set; }
        public string ServiceName { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLowQualityAvatar { get; set; }
        public bool TookPlace { get; set; }
        public bool Canceled { get; set; }
        public int Rate { get; set; }
        public int ReviewId { get; set; }
    }
}