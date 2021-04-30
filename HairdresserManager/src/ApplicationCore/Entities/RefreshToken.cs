using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public Guid AccessTokenJti { get; set; }
        public Guid UserId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Used { get; set; }
    }
}