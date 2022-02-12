using System;
using System.Collections.Generic;
using ApplicationCore.Contract.V1;

namespace ApplicationCore.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}