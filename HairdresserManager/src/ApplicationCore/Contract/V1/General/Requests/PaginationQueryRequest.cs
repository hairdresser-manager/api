namespace ApplicationCore.Contract.V1.General.Requests
{
    public class PaginationQueryRequest
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        
        public int ItemsToSkip() => PerPage * (Page - 1);
    }
}