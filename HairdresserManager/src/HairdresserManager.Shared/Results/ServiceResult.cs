using System.Collections.Generic;

namespace HairdresserManager.Shared.Results
{
    public class ServiceResult<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}