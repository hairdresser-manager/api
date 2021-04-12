using ApplicationCore.Contract.V1.General.Requests;

namespace ApplicationCore.Contract.V1.General.Responses
{
    public class PaginationMetadataResponse
    {
        public PaginationMetadataResponse(PaginationQueryRequest pagination, int allRecords)
        {
            TotalItems = allRecords;
            PerPage = pagination.PerPage;
            CurrentPage = pagination.Page;
            
            TotalPages = (TotalItems + PerPage - 1) / PerPage;
        }
        
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PerPage { get; set; }
    }
}