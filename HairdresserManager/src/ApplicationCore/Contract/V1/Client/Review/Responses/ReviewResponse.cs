namespace ApplicationCore.Contract.V1.Client.Review.Responses
{
    public class ReviewResponse
    {
        public int ReviewId { get; set; }
        public int Rate { get; set; }
        public string Nick { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
    }
}