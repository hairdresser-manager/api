using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class ResourcesCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Resource> Resources { get; set; }
    }
}