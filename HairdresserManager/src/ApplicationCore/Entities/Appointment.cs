using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public string ClientEmail { get; set; }
        public string ClientPhoneNumber { get; set; }
        public int EmployeeId { get; set; }
        public int ServiceId { get; set; }
        public DateTime DateUtc { get; set; }
        public bool TookPlace { get; set; }
        public bool Canceled { get; set; }

        public Client Client { get; set; }
        public Employee Employee { get; set; }
        public Service Service { get; set; }
    }
}