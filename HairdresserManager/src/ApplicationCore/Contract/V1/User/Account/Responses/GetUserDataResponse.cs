using System.Collections.Generic;

namespace ApplicationCore.Contract.V1.User.Account.Responses
{
    public class GetUserDataResponse
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilePhone { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public bool EmailConfirmed { get; set; }
    }
}