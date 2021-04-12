using System;
using System.Collections.Generic;

namespace ApplicationCore.Contract.V1.TeamMembers.Responses
{
    public class GetTeamMemberResponse
    {
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string Description { get; set; }
        public string AvatarUrl { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}