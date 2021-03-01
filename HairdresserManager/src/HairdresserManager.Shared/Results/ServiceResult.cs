using System.Collections.Generic;

namespace HairdresserManager.Shared.Results
{
    public class ServiceResult<T>
    {
        private int _responseCode;
        public bool Success { get; set; }
        public T Data { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public int ResponseCode
        {
            get
            {
                if (_responseCode == 0)
                    return Success ? 200 : 500;

                return _responseCode;
            }
            set => _responseCode = value;
        }

    }
}