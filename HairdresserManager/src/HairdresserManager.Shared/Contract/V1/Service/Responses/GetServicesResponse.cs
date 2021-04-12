using System.Collections;
using System.Collections.Generic;

namespace HairdresserManager.Shared.Contract.V1.Service.Responses
{
    public class GetServicesResponse
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public IEnumerable<string> Employees { get; set; }
        public string Description { get; set; }
        public int MinimumTime { get; set; }
        public int MaximumTime { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
    }
}