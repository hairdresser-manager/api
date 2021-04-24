using System;

namespace ApplicationCore.Entities
{
    public class VerifyEmailKey
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool Used { get; set; }
    }
}