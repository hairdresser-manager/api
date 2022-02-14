using ApplicationCore.Contract.V1.General.Requests;

namespace ApplicationCore.Helpers
{
    public class PaginationHelper
    {
        public PaginationHelper(PaginationQueryRequest pagination)
        {
            PerPage = pagination.PerPage;
            CurrentPage = pagination.CurrentPage;
        }

        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PerPage { get; set; }
        public int TotalPages => (TotalItems + PerPage - 1) / PerPage;
        public int ItemsToSkip => PerPage * (CurrentPage - 1);
    }
}