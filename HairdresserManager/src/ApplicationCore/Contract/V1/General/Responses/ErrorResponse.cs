using System.Collections;
using System.Collections.Generic;

namespace ApplicationCore.Contract.V1.General.Responses
{
    public class ErrorResponse
    {
        public IEnumerable<string> Errors { get; set; }

        public ErrorResponse(string error)
        {
            Errors = new List<string> {error};
        }
        
        public ErrorResponse(IEnumerable<string> errors)
        {
            Errors = errors;
        }
    }
}