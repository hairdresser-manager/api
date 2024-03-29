using System;
using System.Collections.Generic;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Client Client { get; set; }
        public Employee Employee { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; }
        
    }
}