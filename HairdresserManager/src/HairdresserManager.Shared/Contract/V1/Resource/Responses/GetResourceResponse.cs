namespace HairdresserManager.Shared.Contract.V1.Resource.Responses
{
    public class GetResourcesResponse
    {
        public int ResourceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int InStock { get; set; }
        public int Demand { get; set; }
    }
}