namespace Practice13.Services.Models
{
    public class Customer
    {
        public long Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
