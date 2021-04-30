namespace ApplicationCore.Entities
{
    public class ServiceCategory
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int ServiceId { get; set; }

        public Service Service { get; set; }
        public ServicesCategory Category { get; set; }
    }
}