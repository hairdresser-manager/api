using System.Collections.Generic;

namespace ApplicationCore.Results
{
    public class ServiceResult<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}