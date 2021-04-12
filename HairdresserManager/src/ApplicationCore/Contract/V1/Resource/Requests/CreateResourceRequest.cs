using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Contract.V1.Resource.Requests
{
    public class CreateResourceRequest
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        [StringLength(255)]
        public string Description { get; set; }
        
        [StringLength(50)]
        public string Category { get; set; }
        
        public int InStock { get; set; }
        
        public int Demand { get; set; }
    }
}