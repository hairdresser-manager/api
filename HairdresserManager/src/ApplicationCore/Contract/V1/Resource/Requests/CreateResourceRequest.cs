namespace ApplicationCore.Contract.V1.Resource.Requests
{
    public class CreateResourceRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int InStock { get; set; }
        public int Demand { get; set; }
    }
}