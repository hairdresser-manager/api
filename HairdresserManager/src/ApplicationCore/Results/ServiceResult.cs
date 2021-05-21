using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Results
{
    public class ServiceResult
    {
        private ServiceResult(bool succeeded, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
        }

        public bool Succeeded { get; set; }

        public string[] Errors { get; set; }

        public static ServiceResult Success()
        {
            return new(true, new string[]{});
        }

        public static ServiceResult Failure(IEnumerable<string> errors)
        {
            return new(false, errors);
        }
        
        public static ServiceResult Failure(string error)
        {
            return new(false, new List<string>{error});
        }
    }
}