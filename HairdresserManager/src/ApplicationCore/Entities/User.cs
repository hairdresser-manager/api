using System;

namespace ApplicationCore.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Password { get; set; }
        public int MobilePhone { get; set; }
    }
}