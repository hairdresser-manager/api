using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Contract.V1.Resource.Requests
{
    public class UpdateResourceRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Amount { get; set; }
    }
}