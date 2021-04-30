using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class ServicesCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ServiceCategory> ServiceCategories { get; set; }
    }
}