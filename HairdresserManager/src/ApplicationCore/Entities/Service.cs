namespace ApplicationCore.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public int MinimumTime { get; set; }
        public int MaximumTime { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
    }
}