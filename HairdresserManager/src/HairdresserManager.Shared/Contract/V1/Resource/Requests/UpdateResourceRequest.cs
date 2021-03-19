using System.ComponentModel.DataAnnotations;

namespace HairdresserManager.Shared.Contract.V1.Resource.Requests
{
    public class UpdateResourceRequest
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        [StringLength(255)]
        public string Description { get; set; }
        
        [StringLength(50)]
        public string Category { get; set; }
        public string Amount { get; set; }
    }
}