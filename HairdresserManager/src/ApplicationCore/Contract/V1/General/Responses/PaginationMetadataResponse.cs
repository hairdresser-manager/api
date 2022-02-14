using ApplicationCore.Contract.V1.General.Requests;

namespace ApplicationCore.Contract.V1.General.Responses
{
    public class PaginationMetadataResponse
    {
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PerPage { get; set; }
    }
}