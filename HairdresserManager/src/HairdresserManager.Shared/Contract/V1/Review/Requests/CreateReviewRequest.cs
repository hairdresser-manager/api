using System.ComponentModel.DataAnnotations;

namespace HairdresserManager.Shared.Contract.V1.Review.Requests
{
    public class CreateReviewRequest
    {
        [Required]
        public int AppointmentId { get; set; }
        
        [Required]
        [Range(1,5, ErrorMessage = "You rate has to be between 1 and 5")]
        public int Rate { get; set; }

        [StringLength(512, ErrorMessage = "Description has a limit of 512 marks")]
        public string Description { get; set; }
    }
}