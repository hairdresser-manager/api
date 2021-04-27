using System.Collections;
using System.Collections.Generic;

namespace ApplicationCore.Contract.V1.General.Responses
{
    public class ErrorResponse
    {
        public IEnumerable<string> Errors { get; set; }

        public static ErrorResponse New(string error)
        {
            return new() {Errors = new List<string> {error}};
        }
        
        public static ErrorResponse New(IEnumerable<string> errors)
        {
            return new() {Errors = errors};
        }
    }
}