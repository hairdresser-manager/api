using System;
using System.ComponentModel.DataAnnotations;

namespace HairdresserManager.Shared.Contract.V1.General.Requests
{
    public class PaginationQueryRequest
    {
        public int CountItemsToSkip() => PerPage * (Page - 1);

        [Range(1, Int32.MaxValue)]
        public int Page { get; set; }
        
        [Range(1, Int32.MaxValue)]
        public int PerPage { get; set; }
    }
}