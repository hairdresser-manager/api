using System;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class Role : IdentityRole<Guid>
    {
        public const string Admin = "Admin";
        public const string Employee = "Employee";
        public const string User = "User";
    }
}