using System;
using System.Collections.Generic;

namespace ApplicationCore.Results
{
    public class AuthenticationResult : ServiceResult
    {
        public string AccessToken { get; init; }
        public string RefreshToken { get; init; }

        public AuthenticationResult(bool succeeded, IEnumerable<string> errors) : base(succeeded, errors)
        {
        }

        public AuthenticationResult() : base(true, ArraySegment<string>.Empty)
        {
        }
    }
}