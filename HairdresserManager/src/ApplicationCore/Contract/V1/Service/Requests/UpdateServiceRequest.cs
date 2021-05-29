namespace ApplicationCore.Contract.V1.Service.Requests
{
    public class UpdateServiceRequest
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public int MinimumTime { get; set; }
        public int MaximumTime { get; set; }
        public decimal Price { get; set; }
        public bool? Available { get; set; }
    }
}