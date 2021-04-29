using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Results
{
    public class Result
    {
        internal Result(bool succeeded, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
        }

        public bool Succeeded { get; set; }

        public string[] Errors { get; set; }

        public static Result Success()
        {
            return new(true, new string[]{});
        }

        public static Result Failure(IEnumerable<string> errors)
        {
            return new(false, errors);
        }
        
        public static Result Failure(string error)
        {
            return new(false, new List<string>{error});
        }
    }
}