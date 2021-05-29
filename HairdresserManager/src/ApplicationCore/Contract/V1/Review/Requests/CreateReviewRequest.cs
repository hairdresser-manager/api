namespace ApplicationCore.Contract.V1.Review.Requests
{
    public class CreateReviewRequest
    {
        public int AppointmentId { get; set; }
        public int Rate { get; set; }
        public string Description { get; set; }
    }
}