namespace ApplicationCore.Contract.V1.General.Requests
{
    public class PaginationQueryRequest
    {
        public int CurrentPage { get; set; }
        public int PerPage { get; set; }
    }
}